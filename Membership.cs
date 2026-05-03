using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management
{
    public partial class Membership : Form
    {
        public Membership()
        {
            InitializeComponent();

            // REMOVED: dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            StyleDataGridView();
            SetupDurationComboBox();
            LoadMembershipData();
        }

        private void SetupDurationComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("1 Month");
            comboBox1.Items.Add("3 Months");
            comboBox1.Items.Add("6 Months");
            comboBox1.Items.Add("1 Year");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadMembershipData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Membership";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtPrice.Clear();
            comboBox1.SelectedIndex = -1;
            dataGridView1.ClearSelection();
        }

        #region UI Styling
        private void StyleDataGridView()
        {
            ApplyStyle(dataGridView1);
        }

        private void ApplyStyle(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
        }
        #endregion

        #region Form Controls & Navigation

        private void Back_Click(object sender, EventArgs e)
        {
            DashBord Das = new DashBord();
            Das.FormClosed += (s, args) => Application.Exit();
            Das.Show();
            this.Hide();
        }

        private void Add_MemberShip_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please select duration and enter a price.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Membership (Duration, Price) VALUES (@dur, @pr)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dur", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@pr", txtPrice.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Membership plan added successfully!");
                    LoadMembershipData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Update_MemberShip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a plan from the table to update.");
                return;
            }

            // This still works because it looks at the selected row in the grid, 
            // even if the textboxes are empty.
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = @"UPDATE Membership 
                                   SET Duration = COALESCE(NULLIF(@dur, ''), Duration), 
                                       Price = COALESCE(NULLIF(@pr, ''), Price) 
                                   WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dur", comboBox1.SelectedIndex == -1 ? "" : comboBox1.Text);
                    cmd.Parameters.AddWithValue("@pr", txtPrice.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Membership updated successfully!");
                    LoadMembershipData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void Delete_MemberShip_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

            if (MessageBox.Show("Delete this plan?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Membership WHERE ID = @id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Plan deleted.");
                        LoadMembershipData();
                        ClearFields();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Cannot delete: Members are currently using this plan.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Membership WHERE 1=1";
                    SqlCommand cmd = new SqlCommand();

                    if (!string.IsNullOrWhiteSpace(txtID.Text))
                    {
                        query += " AND ID = @id";
                        cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    }
                    if (comboBox1.SelectedIndex != -1)
                    {
                        query += " AND Duration = @dur";
                        cmd.Parameters.AddWithValue("@dur", comboBox1.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        query += " AND Price LIKE @pr";
                        cmd.Parameters.AddWithValue("@pr", "%" + txtPrice.Text.Trim() + "%");
                    }

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        // REMOVED the logic inside this method:
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Left empty so nothing happens when clicking a row
        }

        #endregion
    }
}