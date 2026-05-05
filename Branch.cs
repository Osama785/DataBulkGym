using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.MonthCalendar;

namespace Gym_Management
{
    public partial class Branch : Form
    {
        private int selectedEquipmentId = -1;
        public Branch()
        {
            InitializeComponent();

            SetupTypeCombo();

            LoadBranchData();
            LoadOffers();
            LoadEquipment();
        }

        private void SetupTypeCombo()
        {
            comboType.Items.AddRange(new string[] { "Male", "Female", "Mixed" });
            comboType.SelectedIndex = -1;
        }
        private void ResetInputFields()
        {
            comboType.SelectedIndex = -1; 
            txtCity.Clear();
            txtArea.Clear();
            txtManagerFname.Clear();
            txtManagerLname.Clear();
            txtManagerPhone.Clear();
        }

        private void LoadBranchData()
        {
            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Branch_Manager", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBranch.DataSource = dt;
            }
        }

        private void LoadOffers(int branchId = -1)
        {
            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                string query = branchId == -1 ?
                    "SELECT * FROM Offers" :
                    "SELECT * FROM Offers WHERE Branch_ID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                if (branchId != -1)
                    cmd.Parameters.AddWithValue("@id", branchId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvOffers.DataSource = dt;
            }
        }

        private void LoadEquipment(int branchId = -1)
        {
            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                string query = branchId == -1 ?
                    "SELECT * FROM Equipment" :
                    "SELECT * FROM Equipment WHERE Branch_ID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                if (branchId != -1)
                    cmd.Parameters.AddWithValue("@id", branchId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEquipment.DataSource = dt;
            }
        }

        private void dgvBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBranch.Rows[e.RowIndex];

            int branchId = Convert.ToInt32(row.Cells["Branch_ID"].Value);

            LoadOffers(branchId);
            LoadEquipment(branchId);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                string query = @"
            INSERT INTO Branch_Manager 
            (Type, City, Area, Manager_ID, Manager_Fname, Manager_Lname, Manager_Phone)
            VALUES (@t, @c, @a, NULL, @fn, @ln, @ph);
            DECLARE @ActualID INT = SCOPE_IDENTITY();
            UPDATE Branch_Manager 
            SET Manager_ID = @ActualID 
            WHERE Branch_ID = @ActualID;
            SELECT @ActualID;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@t", comboType.Text);
                    cmd.Parameters.AddWithValue("@c", txtCity.Text);
                    cmd.Parameters.AddWithValue("@a", txtArea.Text);
                    cmd.Parameters.AddWithValue("@fn", txtManagerFname.Text);
                    cmd.Parameters.AddWithValue("@ln", txtManagerLname.Text);
                    cmd.Parameters.AddWithValue("@ph", txtManagerPhone.Text);

                    var result = cmd.ExecuteScalar();
                    MessageBox.Show("Branch created with ID: " + result.ToString());
                }
                LoadBranchData();
                ResetInputFields();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBranch.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvBranch.SelectedRows[0].Cells["Branch_ID"].Value);

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Branch_Manager SET
                    Type=@t, City=@c, Area=@a,
                    Manager_Fname=@fn, Manager_Lname=@ln, Manager_Phone=@ph
                    WHERE Branch_ID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@t", comboType.Text);
                cmd.Parameters.AddWithValue("@c", txtCity.Text);
                cmd.Parameters.AddWithValue("@a", txtArea.Text);
                cmd.Parameters.AddWithValue("@fn", txtManagerFname.Text);
                cmd.Parameters.AddWithValue("@ln", txtManagerLname.Text);
                cmd.Parameters.AddWithValue("@ph", txtManagerPhone.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated!");
                LoadBranchData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBranch.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvBranch.SelectedRows[0].Cells["Branch_ID"].Value);

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                new SqlCommand("DELETE FROM Offers WHERE Branch_ID=@id", con)
                { Parameters = { new SqlParameter("@id", id) } }.ExecuteNonQuery();

                new SqlCommand("DELETE FROM Equipment WHERE Branch_ID=@id", con)
                { Parameters = { new SqlParameter("@id", id) } }.ExecuteNonQuery();

                new SqlCommand("DELETE FROM Branch_Manager WHERE Branch_ID=@id", con)
                { Parameters = { new SqlParameter("@id", id) } }.ExecuteNonQuery();

                MessageBox.Show("Deleted!");

                LoadBranchData();
                LoadOffers();
                LoadEquipment();
            }
        }

        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEquipment.Rows[e.RowIndex];

            selectedEquipmentId = Convert.ToInt32(row.Cells["ID"].Value);

            txtEquipName.Text = row.Cells["Name"].Value.ToString();
            txtEquipDuration.Text = row.Cells["Maintainance_Duration"].Value.ToString();
            dtPurchaseDate.Value = Convert.ToDateTime(row.Cells["Purchase_Date"].Value);
        }
        private void btnUpdateEquipment_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Select equipment first.");
                return;
            }

            if (!int.TryParse(txtEquipDuration.Text, out int duration))
            {
                MessageBox.Show("Invalid duration.");
                return;
            }

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
        UPDATE Equipment 
        SET Name=@n, Purchase_Date=@pd, Maintainance_Duration=@d
        WHERE ID=@id", con);

                cmd.Parameters.AddWithValue("@id", selectedEquipmentId);
                cmd.Parameters.AddWithValue("@n", txtEquipName.Text);
                cmd.Parameters.AddWithValue("@pd", dtPurchaseDate.Value);
                cmd.Parameters.AddWithValue("@d", duration);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Updated!");

                if (dgvBranch.SelectedRows.Count > 0)
                {
                    int branchId = Convert.ToInt32(
                        dgvBranch.SelectedRows[0].Cells["Branch_ID"].Value);

                    LoadEquipment(branchId);
                }
            }
        }
        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            if (dgvBranch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEquipName.Text))
            {
                MessageBox.Show("Equipment name is required.");
                return;
            }

            if (!int.TryParse(txtEquipDuration.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Maintenance duration must be a positive number.");
                return;
            }

            int branchId = Convert.ToInt32(
                dgvBranch.SelectedRows[0].Cells["Branch_ID"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query = @"
                INSERT INTO Equipment 
                (Name, Purchase_Date, Maintainance_Duration, Branch_ID)
                VALUES (@n, @pd, @d, @bid)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@n", txtEquipName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pd", dtPurchaseDate.Value);
                    cmd.Parameters.AddWithValue("@d", duration);
                    cmd.Parameters.AddWithValue("@bid", branchId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Equipment added successfully!");

                    LoadEquipment(branchId);

                    txtEquipName.Clear();
                    txtEquipDuration.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnDeleteEquipment_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId == -1)
            {
                MessageBox.Show("Select equipment first.");
                return;
            }

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Equipment WHERE ID=@id", con);

                cmd.Parameters.AddWithValue("@id", selectedEquipmentId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Deleted!");

                if (dgvBranch.SelectedRows.Count > 0)
                {
                    int branchId = Convert.ToInt32(
                        dgvBranch.SelectedRows[0].Cells["Branch_ID"].Value);

                    LoadEquipment(branchId);
                }

                selectedEquipmentId = -1;
                txtEquipName.Clear();
                txtEquipDuration.Clear();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Branch_Load(object sender, EventArgs e)
        {

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DashBord dashboard = new DashBord();
            dashboard.Show();
            this.Close();
        }
    }
}
