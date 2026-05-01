using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gym_Management
{
    public partial class Member : Form
    {

        public Member()
        {
            InitializeComponent();

            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;

            StyleDataGridView();
            LoadMemberData();
            LoadPhoneData();
            ClearFields();

            SetupGenderComboBox();
            LoadMembershipOptions();
            LoadBranchOptions();
            LoadPlanOptions();
        }

        #region ComboBox Data Loading Methods

        // Setup Gender Options (Static)
        private void SetupGenderComboBox()
        {
            Gender.Items.Clear();
            Gender.Items.Add("Male");
            Gender.Items.Add("Female");
            Gender.DropDownStyle = ComboBoxStyle.DropDownList;
            Gender.SelectedIndex = -1;
        }

        // Load Membership Options (Combined Duration + Price)
        private void LoadMembershipOptions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT ID, Duration, Price FROM Membership";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Create virtual column: "1 Month - 300.00 EGP"
                    dt.Columns.Add("FullInfo", typeof(string), "Duration + ' - ' + Price + ' EGP'");

                    comboBoxMembership.DataSource = dt;
                    comboBoxMembership.DisplayMember = "FullInfo";
                    comboBoxMembership.ValueMember = "ID";
                    comboBoxMembership.SelectedIndex = -1;
                    comboBoxMembership.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Membership Load Error: " + ex.Message);
            }
        }

        // Load Branch Options (Combined Type + City + Area)
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

                    // Create virtual column: "Main | Cairo - Nasr City"
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

        // Load Workout Plan Options (Combined Name + Duration + Intensity)
        private void LoadPlanOptions()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT ID, Name, Duration, Intensity_Level FROM Workout_Plan";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    // Create the combined display column
                    dt.Columns.Add("PlanInfo", typeof(string), "Name + ' - ' + Duration + ' wks (' + Intensity_Level + ')'");

                    // --- NEW: Add the "-- No Plan --" row at the top ---
                    DataRow dr = dt.NewRow();
                    dr["ID"] = -1; // We use -1 to represent NULL in our logic
                    dr["PlanInfo"] = "-- No Plan --";
                    dt.Rows.InsertAt(dr, 0); // Insert at the very first position

                    comboBoxPlan.DataSource = dt;
                    comboBoxPlan.DisplayMember = "PlanInfo";
                    comboBoxPlan.ValueMember = "ID";

                    comboBoxPlan.SelectedIndex = -1; // Start empty so it doesn't filter by default
                    comboBoxPlan.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plan Load Error: " + ex.Message);
            }
        }

        #endregion

        #region Table Data Loading & Master-Detail Logic

        private void ClearFields()
        {
            // Clear TextBoxes
            txtID.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtPhone.Clear();

            // Reset ComboBoxes (Selection only)
            Gender.SelectedIndex = -1;
            comboBoxMembership.SelectedIndex = -1;
            comboBoxPlan.SelectedIndex = -1;

            // FIX: Don't set DataSource to null, just reset the index
            if (comboBoxBranch.DataSource != null)
                comboBoxBranch.SelectedIndex = -1;

            // Clear Grid selections
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void LoadMemberData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Member";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Member Table Error: " + ex.Message);
            }
        }

        private void LoadPhoneData(int memberId = -1)
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query;
                    SqlCommand cmd;

                    if (memberId == -1)
                    {
                        query = "SELECT * FROM Member_Phone";
                        cmd = new SqlCommand(query, con);
                    }
                    else
                    {
                        query = "SELECT * FROM Member_Phone WHERE Member_ID=@id";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", memberId);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Master-Detail Trigger: Clicking a row in the Member table filters the Phone table
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                LoadPhoneData(id);
            }
        }

        #endregion

        #region UI Styling

        private void StyleDataGridView()
        {
            ApplyStyle(dataGridView1);
            if (dataGridView2 != null) ApplyStyle(dataGridView2);
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

        // Empty event handlers to prevent designer errors
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Member_Load(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent the code from running if no gender is selected yet
            if (Gender.SelectedIndex == -1) return;

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query = "";

                    if (Gender.Text == "Female")
                        query = "SELECT * FROM Branch_Manager WHERE Type IN ('Female','Mixed')";
                    else
                        query = "SELECT * FROM Branch_Manager WHERE Type IN ('Male','Mixed')";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // --- ADDED: Create a combined column for display ---
                    // This creates a format like: "Cairo - Nasr City (Mixed)"
                    dt.Columns.Add("FullBranchInfo", typeof(string), "City + ' - ' + Area + ' (' + Type + ')'");

                    comboBoxBranch.DataSource = dt;

                    // --- UPDATED: Set the display to the new combined column ---
                    comboBoxBranch.DisplayMember = "FullBranchInfo";
                    comboBoxBranch.ValueMember = "Branch_ID";

                    comboBoxBranch.SelectedIndex = -1; // Reset selection so user has to pick
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading branches: " + ex.Message);
            }
        }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void comboBoxMembership_SelectedIndexChanged(object sender, EventArgs e) { }

        #endregion

        private void Add_Member_Click(object sender, EventArgs e)
        {
            // --- 1. UI VALIDATION LAYER ---
            // Check for empty fields
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("Validation Error: First Name cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Validation Error: Last Name cannot be empty.");
                return;
            }
            if (Gender.SelectedIndex == -1)
            {
                MessageBox.Show("Validation Error: Please select a Gender.");
                return;
            }
            if (comboBoxMembership.SelectedIndex == -1)
            {
                MessageBox.Show("Validation Error: Please select a Membership type.");
                return;
            }
            if (comboBoxBranch.SelectedIndex == -1)
            {
                MessageBox.Show("Validation Error: Please select a Branch.");
                return;
            }

            // Phone validation (11 digits, starts with 01)
            if (txtPhone.Text.Length != 11 || !txtPhone.Text.StartsWith("01"))
            {
                MessageBox.Show("Validation Error: Phone must be exactly 11 digits and start with '01'.");
                return;
            }

            // --- 2. DATA PREPARATION ---
            // Capitalize first letter, lowercase the rest
            string formattedFname = char.ToUpper(txtFname.Text[0]) + txtFname.Text.Substring(1).ToLower();
            string formattedLname = char.ToUpper(txtLname.Text[0]) + txtLname.Text.Substring(1).ToLower();

            // --- 3. DATABASE EXECUTION LAYER ---
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    // SQL Query to insert member and get the new ID
                    string query = @"
                INSERT INTO Member 
                (Fname, Lname, Gender, Join_Date, Membership_ID, Start_Date, Branch_ID, Plan_ID)
                VALUES 
                (@fn, @ln, @g, @jd, @mid, @sd, @bid, @pid);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fn", formattedFname);
                    cmd.Parameters.AddWithValue("@ln", formattedLname);
                    cmd.Parameters.AddWithValue("@g", Gender.Text);
                    cmd.Parameters.AddWithValue("@jd", DateTime.Today);
                    cmd.Parameters.AddWithValue("@mid", comboBoxMembership.SelectedValue);
                    cmd.Parameters.AddWithValue("@sd", dateStart.SelectionStart);
                    cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedValue);

                    // Handle optional Plan (Index -1 or our custom "-- No Plan --" item)
                    if (comboBoxPlan.SelectedIndex == -1 || (int)comboBoxPlan.SelectedValue == -1)
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@pid", comboBoxPlan.SelectedValue);

                    // Execute scalar to get the auto-generated ID
                    int newMemberID = Convert.ToInt32(cmd.ExecuteScalar());

                    // Add the first phone number to the Phone table
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Member_Phone (Member_ID, Phone) VALUES (@id, @ph)", con);
                    cmd2.Parameters.AddWithValue("@id", newMemberID);
                    cmd2.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                    cmd2.ExecuteNonQuery();

                    // 4. SUCCESS FEEDBACK
                    MessageBox.Show("Success: Member and Phone number added successfully!");

                    // Refresh the tables and clear the form
                    LoadMemberData();
                    LoadPhoneData(newMemberID);
                    ClearFields();
                }
            }
            // --- 5. DATABASE ERROR HANDLING ---
            catch (SqlException ex)
            {
                // 2627 and 2601 are SQL codes for Primary Key/Unique violations
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Database Error: This Phone number already exists in the system.");
                }
                else
                {
                    MessageBox.Show("Database Error (" + ex.Number + "): " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
            }
        }
        private void Delete_Member_Click(object sender, EventArgs e)
        {
            // 1. Check if the user has selected a row in the table
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a full row in the table to delete.");
                return;
            }

            // 2. Get the ID from the first cell (index 0) of the selected row
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            // Confirmation message (Safety first!)
            if (MessageBox.Show("Are you sure you want to delete this member?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();

                // 3. Delete Phone first (Foreign Key constraint)
                SqlCommand cmd1 = new SqlCommand("DELETE FROM Member_Phone WHERE Member_ID = @id", con);
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.ExecuteNonQuery();

                // 4. Delete the Member
                SqlCommand cmd2 = new SqlCommand("DELETE FROM Member WHERE ID = @id", con);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Member deleted successfully!");

                // 5. Refresh your table to show it's gone
                LoadMemberData();
                LoadPhoneData();
                ClearFields();
            }
        }
        private void btnNoPlan_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
            {
                con.Open();
                // Specifically look for people with NO plan
                string query = "SELECT * FROM Member WHERE Plan_ID IS NULL";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0) MessageBox.Show("All members have a plan.");
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query = @"SELECT DISTINCT M.* 
                             FROM Member M 
                             LEFT JOIN Member_Phone P ON M.ID = P.Member_ID 
                             WHERE 1=1";

                    SqlCommand cmd = new SqlCommand();

                    // Filters
                    if (!string.IsNullOrWhiteSpace(txtID.Text)) { query += " AND M.ID = @id"; cmd.Parameters.AddWithValue("@id", txtID.Text.Trim()); }
                    if (!string.IsNullOrWhiteSpace(txtPhone.Text)) { query += " AND P.Phone = @ph"; cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim()); }
                    if (!string.IsNullOrWhiteSpace(txtFname.Text)) { query += " AND M.Fname LIKE @fn"; cmd.Parameters.AddWithValue("@fn", "%" + txtFname.Text.Trim() + "%"); }
                    if (!string.IsNullOrWhiteSpace(txtLname.Text)) { query += " AND M.Lname LIKE @ln"; cmd.Parameters.AddWithValue("@ln", "%" + txtLname.Text.Trim() + "%"); }
                    if (Gender.SelectedIndex != -1) { query += " AND M.Gender = @g"; cmd.Parameters.AddWithValue("@g", Gender.Text); }
                    if (comboBoxMembership.SelectedIndex != -1) { query += " AND M.Membership_ID = @mid"; cmd.Parameters.AddWithValue("@mid", comboBoxMembership.SelectedValue); }
                    if (comboBoxBranch.SelectedIndex != -1) { query += " AND M.Branch_ID = @bid"; cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedValue); }

                    // Plan Logic
                    if (comboBoxPlan.SelectedIndex != -1)
                    {
                        int planID = Convert.ToInt32(comboBoxPlan.SelectedValue);
                        if (planID == -1) query += " AND M.Plan_ID IS NULL";
                        else { query += " AND M.Plan_ID = @pid"; cmd.Parameters.AddWithValue("@pid", planID); }
                    }

                    cmd.Connection = con;
                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0) MessageBox.Show("No members found matching those filters.");

                    // --- ADDED: Clear everything so the user can start a new search ---
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during search: " + ex.Message);
            }
        }
        private void Add_Phone_Click(object sender, EventArgs e)
        {

            // 1. Check if the user entered a phone number
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            // 2. Check if a member is selected in the table to get their ID
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member from the table first.");
                return;
            }

            // 3. Get the ID from the first cell of the selected row
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    // 4. Create the SQL Command
                    string query = "INSERT INTO Member_Phone (Member_ID, Phone) VALUES (@id, @phone)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // 5. Use Parameters to prevent SQL Injection
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());

                    // 6. Execute the query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Phone number added successfully!");

                    // 7. Refresh the phone table and clear the textbox
                    LoadPhoneData(id);
                    txtPhone.Clear();
                }
            }
            catch (SqlException ex)
            {
                // Handle duplicate phone numbers (Primary Key violation)
                if (ex.Number == 2627)
                    MessageBox.Show("This phone number already exists for this member.");
                else
                    MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void Delete_Phone_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is selected in the PHONE table (dataGridView2)
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select the phone number row you want to delete.");
                return;
            }

            // 2. Get the Member_ID and Phone from the selected row
            // Assuming Column 0 is Member_ID and Column 1 is Phone
            int memberId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            string phoneNumber = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();

            // 3. Confirm deletion
            DialogResult confirm = MessageBox.Show($"Delete phone {phoneNumber}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                    {
                        con.Open();

                        // 4. SQL command to delete specific phone for specific member
                        string query = "DELETE FROM Member_Phone WHERE Member_ID = @id AND Phone = @phone";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@id", memberId);
                        cmd.Parameters.AddWithValue("@phone", phoneNumber);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Phone number deleted successfully.");

                        // 5. Refresh the phone table to show it's gone
                        LoadPhoneData(memberId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            LoadPhoneData(memberId);
            ClearFields();
        }
        private void dateJoin_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Update_Member_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Error: Please select a member from the table to update.");
                return;
            }

            int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    // 1. ADDED Start_Date to the COALESCE logic
                    string query = @"
                UPDATE Member 
                SET Fname = COALESCE(NULLIF(@fn, ''), Fname), 
                    Lname = COALESCE(NULLIF(@ln, ''), Lname), 
                    Gender = COALESCE(NULLIF(@g, ''), Gender), 
                    Membership_ID = COALESCE(@mid, Membership_ID), 
                    Branch_ID = COALESCE(@bid, Branch_ID), 
                    Plan_ID = COALESCE(@pid, Plan_ID),
                    Start_Date = COALESCE(@sd, Start_Date) 
                WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", selectedID);

                    // 2. Handle TextBoxes
                    string fn = txtFname.Text.Trim();
                    string ln = txtLname.Text.Trim();
                    cmd.Parameters.AddWithValue("@fn", string.IsNullOrEmpty(fn) ? "" : char.ToUpper(fn[0]) + fn.Substring(1).ToLower());
                    cmd.Parameters.AddWithValue("@ln", string.IsNullOrEmpty(ln) ? "" : char.ToUpper(ln[0]) + ln.Substring(1).ToLower());

                    // 3. Handle ComboBoxes
                    cmd.Parameters.AddWithValue("@g", Gender.SelectedIndex == -1 ? "" : Gender.Text);
                    cmd.Parameters.AddWithValue("@mid", comboBoxMembership.SelectedIndex == -1 ? (object)DBNull.Value : comboBoxMembership.SelectedValue);
                    cmd.Parameters.AddWithValue("@bid", comboBoxBranch.SelectedIndex == -1 ? (object)DBNull.Value : comboBoxBranch.SelectedValue);

                    // 4. ADDED: Handle Start Date from Calendar
                    // We pass the selection from the calendar
                    cmd.Parameters.AddWithValue("@sd", dateStart.SelectionStart);

                    // 5. Handle Plan
                    if (comboBoxPlan.SelectedIndex == -1)
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                    else if ((int)comboBoxPlan.SelectedValue == -1)
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@pid", comboBoxPlan.SelectedValue);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Update Successful: Changes saved.");
                        LoadMemberData();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }
    }
}