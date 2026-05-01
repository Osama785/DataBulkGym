using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management
{
    public partial class Trainers : Form
    {
        public Trainers()
        {
            InitializeComponent();

            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            StyleDataGridView();
            LoadTrainerData();
            ClearFields();

            SetupGenderComboBox();
            SetupShiftComboBox();
            SetupSpecialityComboBox();
            LoadBranchOptions();
        }

        #region ComboBox Data Loading Methods

        private void SetupGenderComboBox()
        {
            comboBoxGender.Items.Clear();
            comboBoxGender.Items.Add("Male");
            comboBoxGender.Items.Add("Female");
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.SelectedIndex = -1;
        }

        private void SetupShiftComboBox()
        {
            comboBoxShift.Items.Clear();
            comboBoxShift.Items.Add("Morning");
            comboBoxShift.Items.Add("Evening");
            comboBoxShift.Items.Add("Night");
            comboBoxShift.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShift.SelectedIndex = -1;
        }

        private void SetupSpecialityComboBox()
        {
            comboBoxSpeciality.Items.Clear();
            comboBoxSpeciality.Items.Add("Cardio");
            comboBoxSpeciality.Items.Add("Yoga");
            comboBoxSpeciality.Items.Add("Strength");
            comboBoxSpeciality.Items.Add("CrossFit");
            comboBoxSpeciality.Items.Add("Pilates");
            comboBoxSpeciality.Items.Add("Zumba");
            comboBoxSpeciality.Items.Add("Bodybuilding");
            comboBoxSpeciality.Items.Add("Aerobics");
            comboBoxSpeciality.Items.Add("Powerlifting");
            comboBoxSpeciality.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpeciality.SelectedIndex = -1;
        }

        private void LoadBranchOptions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT Branch_ID, Type, City, Area FROM Branch_Manager";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dt.Columns.Add("BranchInfo", typeof(string), "Type + ' | ' + City + ' - ' + Area");

                    comboBoxBranch.DataSource = dt;
                    comboBoxBranch.DisplayMember = "BranchInfo";
                    comboBoxBranch.ValueMember = "Branch_ID";
                    comboBoxBranch.SelectedIndex = -1;
                    comboBoxBranch.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Branch Load Error: " + ex.Message);
            }
        }

        #endregion

        #region Table Data Loading

        private void ClearFields()
        {
            txtID.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();

            comboBoxGender.SelectedIndex = -1;
            comboBoxShift.SelectedIndex = -1;
            comboBoxSpeciality.SelectedIndex = -1;

            if (comboBoxBranch.DataSource != null)
                comboBoxBranch.SelectedIndex = -1;

            dataGridView1.ClearSelection();
        }

        private void LoadTrainerData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Trainer";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trainer Table Error: " + ex.Message);
            }
        }

        // Clicking a row populates the input fields for easy editing
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtID.Text    = row.Cells["ID"].Value?.ToString();
                txtFname.Text = row.Cells["Fname"].Value?.ToString();
                txtLname.Text = row.Cells["Lname"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();

                comboBoxGender.SelectedItem    = row.Cells["Gender"].Value?.ToString();
                comboBoxShift.SelectedItem     = row.Cells["Shift"].Value?.ToString();
                comboBoxSpeciality.SelectedItem = row.Cells["Speciality"].Value?.ToString();

                if (row.Cells["Branch_ID"].Value != null)
                    comboBoxBranch.SelectedValue = row.Cells["Branch_ID"].Value;
            }
        }

        #endregion

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

        #endregion

        #region CRUD Operations

        private void Add_Trainer_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            { MessageBox.Show("Validation Error: First Name cannot be empty."); return; }
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            { MessageBox.Show("Validation Error: Last Name cannot be empty."); return; }
            if (comboBoxGender.SelectedIndex == -1)
            { MessageBox.Show("Validation Error: Please select a Gender."); return; }
            if (comboBoxBranch.SelectedIndex == -1)
            { MessageBox.Show("Validation Error: Please select a Branch."); return; }
            if (txtPhone.Text.Length != 11 || !txtPhone.Text.StartsWith("01"))
            { MessageBox.Show("Validation Error: Phone must be 11 digits starting with '01'."); return; }

            string formattedFname = char.ToUpper(txtFname.Text[0]) + txtFname.Text.Substring(1).ToLower();
            string formattedLname = char.ToUpper(txtLname.Text[0]) + txtLname.Text.Substring(1).ToLower();

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = @"
                        INSERT INTO Trainer (Fname, Lname, Gender, Shift, Speciality, Phone, Branch_ID)
                        VALUES (@fn, @ln, @g, @sh, @sp, @ph, @bid)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fn", formattedFname);
                    cmd.Parameters.AddWithValue("@ln", formattedLname);
                    cmd.Parameters.AddWithValue("@g",  comboBoxGender.Text);
                    cmd.Parameters.AddWithValue("@sh", comboBoxShift.SelectedIndex == -1 ? (object)DBNull.Value : comboBoxShift.Text);
                    cmd.Parameters.AddWithValue("@sp", comboBoxSpeciality.SelectedIndex == -1 ? (object)DBNull.Value : comboBoxSpeciality.Text);
                    cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedValue);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success: Trainer added successfully!");
                    LoadTrainerData();
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("Database Error: This Phone number already exists in the system.");
                else
                    MessageBox.Show("Database Error (" + ex.Number + "): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
            }
        }

        private void Delete_Trainer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            { MessageBox.Show("Please select a row in the table to delete."); return; }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Trainer WHERE ID = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trainer deleted successfully!");
                    LoadTrainerData();
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                // FK violation: trainer is assigned to a Workout_Plan or Class
                if (ex.Number == 547)
                    MessageBox.Show("Cannot delete: This trainer is assigned to a Workout Plan or Class.");
                else
                    MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void Update_Trainer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            { MessageBox.Show("Error: Please select a trainer from the table to update."); return; }

            int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = @"
                        UPDATE Trainer
                        SET Fname       = COALESCE(NULLIF(@fn, ''), Fname),
                            Lname       = COALESCE(NULLIF(@ln, ''), Lname),
                            Gender      = COALESCE(NULLIF(@g, ''), Gender),
                            Shift       = COALESCE(NULLIF(@sh, ''), Shift),
                            Speciality  = COALESCE(NULLIF(@sp, ''), Speciality),
                            Phone       = COALESCE(NULLIF(@ph, ''), Phone),
                            Branch_ID   = COALESCE(@bid, Branch_ID)
                        WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    string fn = txtFname.Text.Trim();
                    string ln = txtLname.Text.Trim();
                    cmd.Parameters.AddWithValue("@fn", string.IsNullOrEmpty(fn) ? "" : char.ToUpper(fn[0]) + fn.Substring(1).ToLower());
                    cmd.Parameters.AddWithValue("@ln", string.IsNullOrEmpty(ln) ? "" : char.ToUpper(ln[0]) + ln.Substring(1).ToLower());
                    cmd.Parameters.AddWithValue("@g",  comboBoxGender.SelectedIndex == -1 ? "" : comboBoxGender.Text);
                    cmd.Parameters.AddWithValue("@sh", comboBoxShift.SelectedIndex == -1 ? "" : comboBoxShift.Text);
                    cmd.Parameters.AddWithValue("@sp", comboBoxSpeciality.SelectedIndex == -1 ? "" : comboBoxSpeciality.Text);
                    cmd.Parameters.AddWithValue("@ph", string.IsNullOrWhiteSpace(txtPhone.Text) ? "" : txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedIndex == -1 ? (object)DBNull.Value : comboBoxBranch.SelectedValue);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Update Successful: Changes saved.");
                        LoadTrainerData();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Trainer WHERE 1=1";
                    SqlCommand cmd = new SqlCommand();

                    if (!string.IsNullOrWhiteSpace(txtID.Text))
                    { query += " AND ID = @id"; cmd.Parameters.AddWithValue("@id", txtID.Text.Trim()); }
                    if (!string.IsNullOrWhiteSpace(txtFname.Text))
                    { query += " AND Fname LIKE @fn"; cmd.Parameters.AddWithValue("@fn", "%" + txtFname.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(txtLname.Text))
                    { query += " AND Lname LIKE @ln"; cmd.Parameters.AddWithValue("@ln", "%" + txtLname.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                    { query += " AND Phone = @ph"; cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim()); }
                    if (comboBoxGender.SelectedIndex != -1)
                    { query += " AND Gender = @g"; cmd.Parameters.AddWithValue("@g", comboBoxGender.Text); }
                    if (comboBoxShift.SelectedIndex != -1)
                    { query += " AND Shift = @sh"; cmd.Parameters.AddWithValue("@sh", comboBoxShift.Text); }
                    if (comboBoxSpeciality.SelectedIndex != -1)
                    { query += " AND Speciality = @sp"; cmd.Parameters.AddWithValue("@sp", comboBoxSpeciality.Text); }
                    if (comboBoxBranch.SelectedIndex != -1)
                    { query += " AND Branch_ID = @bid"; cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedValue); }

                    cmd.Connection = con;
                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                        MessageBox.Show("No trainers found matching those filters.");

                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during search: " + ex.Message);
            }
        }

        #endregion

        // Empty stubs required by Designer
        private void Trainers_Load(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
