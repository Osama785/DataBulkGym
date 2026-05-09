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

namespace Gym_Management
{
    public partial class ClassScheduler : Form
    {
        private int _selectedClassID = -1;
        private string _selectedScheduleDay = "";
        private string _selectedScheduleTime = "";

        private enum SelectionContext { None, Class, Schedule }
        private SelectionContext _currentContext = SelectionContext.None;


        public ClassScheduler()
        {
            InitializeComponent();

            // Wire events 
            dgvClasses.CellClick += dgvClasses_CellClick;
            dgvSchedules.CellClick += dgvSchedules_CellClick;


            btnAddClass.Click += btnAddClass_Click;
            btnUpdateClass.Click += btnUpdateClass_Click;
            btnDeleteClass.Click += btnDeleteClass_Click;

            btnAddScheduleOnly.Click += btnAddScheduleOnly_Click;
            btnDeleteSchedule.Click += btnDeleteSchedule_Click;

            btnClear.Click += (s, e) => ClearFields();
            btnBack.Click += btnBack_Click;

            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.MultiSelect = false;
            dgvSchedules.MultiSelect = false;

            SetButtonStates(SelectionContext.None);
            LoadClassData();
            LoadScheduleData();
            LoadTrainerComboBox();
            LoadDayComboBox();
        }


        private void LoadClassData()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {

                    con.Open();
                    string query = @"SELECT c.ID, c.Name, t.Fname + ' ' + t.Lname AS Trainer
                             FROM Class c
                             JOIN Trainer t ON c.Trainer_ID = t.ID";


                    SqlDataAdapter sda = new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    dgvClasses.DataSource = dt;
                    dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                // If anything fails (wrong query, server down, etc.), we catch it here.
                // We show a message box so the user knows something went wrong
                MessageBox.Show("Class Table Error: " + ex.Message);
            }
        }

        private void LoadScheduleData(int classId = -1)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query;
                    SqlCommand cmd;

                    if (classId == -1)
                    {
                        // Show ALL schedules
                        query = @"SELECT cs.Class_ID, c.Name AS ClassName, cs.Day, cs.Time
                                 FROM Class_Schedule cs
                                 JOIN Class c ON cs.Class_ID = c.ID
                                 ORDER BY c.Name, cs.Day, cs.Time";
                        cmd = new SqlCommand(query, con);
                    }
                    else
                    {
                        // Show ONLY schedules for selected class
                        query = @"SELECT cs.Class_ID, c.Name AS ClassName, cs.Day, cs.Time
                                 FROM Class_Schedule cs
                                 JOIN Class c ON cs.Class_ID = c.ID
                                 WHERE cs.Class_ID = @id
                                 ORDER BY cs.Day, cs.Time";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", classId);
                    }

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dgvSchedules.DataSource = dt;

                    // Style the schedules grid
                    dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvSchedules.AllowUserToAddRows = false;
                    dgvSchedules.ReadOnly = true;
                    dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvSchedules.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Schedule Load Error: " + ex.Message);
            }
        }

        private void LoadTrainerComboBox()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    // Combine name and speciality for display
                    string query = "SELECT ID, Fname + ' ' + Lname + ' (' + Speciality + ')' AS TrainerInfo FROM Trainer";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    cmbTrainer.DataSource = dt;
                    cmbTrainer.DisplayMember = "TrainerInfo"; // What the user sees
                    cmbTrainer.ValueMember = "ID";            // What the database needs
                    cmbTrainer.SelectedIndex = -1;            // Start empty
                    cmbTrainer.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            catch (Exception ex) { MessageBox.Show("Trainer Load Error: " + ex.Message); }
        }

        private void LoadDayComboBox()
        {
            cmbDay.Items.Clear();
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            cmbDay.Items.AddRange(days);
            cmbDay.SelectedIndex = -1;
            cmbDay.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ClassScheduler_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void cmbTrainer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void btnAddClass_Click(object sender, EventArgs e)
        {
            // validation
            if (string.IsNullOrWhiteSpace(txtClassName.Text))
            { MessageBox.Show("Class name cannot be empty."); return; }
            if (cmbTrainer.SelectedIndex == -1)
            { MessageBox.Show("Please select a trainer."); return; }
            if (cmbDay.SelectedIndex == -1)
            { MessageBox.Show("Please select a day."); return; }

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();
                    // Begin a transaction: all or nothing
                    using (SqlTransaction tran = con.BeginTransaction())
                    {
                        try
                        {
                            // Insert Class & Get New ID
                            string insertClass = @"INSERT INTO Class (Name, Trainer_ID) 
                                           VALUES (@name, @tid); 
                                           SELECT SCOPE_IDENTITY();";
                            SqlCommand cmdClass = new SqlCommand(insertClass, con, tran);
                            cmdClass.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                            cmdClass.Parameters.AddWithValue("@tid", cmbTrainer.SelectedValue);

                            // ExecuteScalar (return is one value) returns the first column of the first row (our new ID)
                            int newClassId = Convert.ToInt32(cmdClass.ExecuteScalar());

                            //  Insert Schedule for the new class
                            string insertSchedule = @"INSERT INTO Class_Schedule (Class_ID, Day, Time) 
                                              VALUES (@cid, @day, @time)";
                            SqlCommand cmdSchedule = new SqlCommand(insertSchedule, con, tran);
                            cmdSchedule.Parameters.AddWithValue("@cid", newClassId);
                            cmdSchedule.Parameters.AddWithValue("@day", cmbDay.Text);
                            // Format time as HH:mm:ss to match SQL TIME type exactly
                            cmdSchedule.Parameters.AddWithValue("@time", dtpTime.Value.ToString("HH:mm:ss"));

                            cmdSchedule.ExecuteNonQuery();

                            // Commit Transaction
                            tran.Commit();
                            MessageBox.Show("Class and schedule added successfully!");

                            // Refresh UI & Reset
                            LoadClassData();
                            LoadScheduleData();
                            ClearFields();
                            return;
                        }
                        catch
                        {
                            // If ANY step fails, roll back everything
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // 2627/2601 = Primary/Unique Key violation (duplicate schedule)

                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("This time slot already exists for the selected class.");
                else
                    MessageBox.Show($"Database Error ({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }

        private void btnAddScheduleOnly_Click(object sender, EventArgs e)
        {
            // validation
            if (_selectedClassID == -1)
            {
                MessageBox.Show("Please select a class from the table first.");
                return;
            }
            if (cmbDay.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a day.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    //GUARD CHECK: Verify class doesn't already have a schedule on this day because class scheduler primary key= classid + day
                    string checkQuery = @"SELECT COUNT(*) FROM Class_Schedule 
                                  WHERE Class_ID = @cid AND Day = @day";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@cid", _selectedClassID);
                    checkCmd.Parameters.AddWithValue("@day", cmbDay.Text);

                    int existingSchedules = (int)checkCmd.ExecuteScalar();

                    if (existingSchedules > 0)
                    {
                        MessageBox.Show($"This class already has a schedule on {cmbDay.Text}. Each class can only occur once per day.");
                        return; // Stop execution
                    }


                    string query = @"INSERT INTO Class_Schedule (Class_ID, Day, Time) 
                             VALUES (@cid, @day, @time)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cid", _selectedClassID);
                    cmd.Parameters.AddWithValue("@day", cmbDay.Text);
                    cmd.Parameters.AddWithValue("@time", dtpTime.Value.ToString("HH:mm:ss"));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Schedule added successfully!");

                    // Refresh only the schedule grid
                    LoadScheduleData(_selectedClassID);

                    // Clear schedule fields but keep class selection
                    cmbDay.SelectedIndex = -1;
                    dtpTime.Value = DateTime.Today.AddHours(9);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("This time slot already exists for the selected class.");
                else
                    MessageBox.Show($"Database Error ({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvClasses.Rows[e.RowIndex];
            int clickedClassID = Convert.ToInt32(row.Cells["ID"].Value);

            // CHECK: Is this the same class already selected?
            if (_selectedClassID == clickedClassID)
            {
                // yes -> deselect everything
                dgvClasses.ClearSelection();
                dgvSchedules.ClearSelection();

                // Clear form fields
                txtClassName.Clear();
                cmbTrainer.SelectedIndex = -1;
                cmbDay.SelectedIndex = -1;

                // Reset state
                _selectedClassID = -1;
                _selectedScheduleDay = "";
                _selectedScheduleTime = "";
                _currentContext = SelectionContext.None;

                // Show all schedules
                LoadScheduleData();

                // Disable buttons
                SetButtonStates(SelectionContext.None);
            }
            else
            {
                // no -> select this class
                _currentContext = SelectionContext.Class;
                _selectedClassID = clickedClassID;

                // Populate form fields
                txtClassName.Text = row.Cells["Name"].Value?.ToString();

                // Match trainer in ComboBox
                string trainerName = row.Cells["Trainer"].Value?.ToString();
                if (!string.IsNullOrEmpty(trainerName) && cmbTrainer.DataSource != null)
                {
                    foreach (DataRowView item in cmbTrainer.Items)
                    {
                        if (item["TrainerInfo"].ToString() == trainerName)
                        {
                            cmbTrainer.SelectedValue = item["ID"];
                            break;
                        }
                    }
                }

                // Clear schedule-specific fields
                _selectedScheduleDay = "";
                _selectedScheduleTime = "";
                cmbDay.SelectedIndex = -1;
                dtpTime.Value = DateTime.Today.AddHours(9);

                // Load this class's schedules
                LoadScheduleData(_selectedClassID);

                // Enable class buttons
                SetButtonStates(SelectionContext.Class);
            }
        }

        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0) return;

            _currentContext = SelectionContext.Schedule;

            DataGridViewRow row = dgvSchedules.Rows[e.RowIndex];

            // Capture the composite key (Class_ID + Day + Time)
            _selectedClassID = Convert.ToInt32(row.Cells["Class_ID"].Value);
            _selectedScheduleDay = row.Cells["Day"].Value?.ToString();
            _selectedScheduleTime = row.Cells["Time"].Value?.ToString();

            // Populate schedule input fields
            cmbDay.Text = _selectedScheduleDay;
            if (DateTime.TryParse(_selectedScheduleTime, out DateTime parsedTime))
                dtpTime.Value = parsedTime;

            // Update UI state
            SetButtonStates(_currentContext);
        }

        private void SetButtonStates(SelectionContext context)
        {
            // Reset all to disabled & gray
            btnUpdateClass.Enabled = btnDeleteClass.Enabled = false;
            btnAddScheduleOnly.Enabled = false; 

            Color disabledColor = SystemColors.ControlLight;
            Color disabledText = SystemColors.GrayText;

            btnUpdateClass.BackColor = btnDeleteClass.BackColor = btnAddScheduleOnly.BackColor= btnDeleteSchedule.BackColor = disabledColor;
            btnUpdateClass.ForeColor = btnDeleteClass.ForeColor = btnAddScheduleOnly.ForeColor = btnDeleteSchedule.ForeColor = disabledText;


            // Activate based on context
            if (context == SelectionContext.Class)
            {
                btnUpdateClass.Enabled = btnDeleteClass.Enabled = true;
                btnUpdateClass.BackColor = Color.FromArgb(0, 120, 215); // Blue
                btnUpdateClass.ForeColor = Color.White;
                btnDeleteClass.BackColor = Color.FromArgb(200, 50, 50); // Red
                btnDeleteClass.ForeColor = Color.White;
                btnAddScheduleOnly.Enabled = true;
                btnAddScheduleOnly.BackColor = Color.FromArgb(40, 167, 69); // Green
                btnAddScheduleOnly.ForeColor = Color.White;
            }
            else if (context == SelectionContext.Schedule)
            {
                btnDeleteSchedule.Enabled = true;
                btnDeleteSchedule.BackColor = Color.FromArgb(200, 50, 50); // Red
                btnDeleteSchedule.ForeColor = Color.White;
            }
        }

        private void ClearFields()
        {
            txtClassName.Clear();
            cmbTrainer.SelectedIndex = -1;
            cmbDay.SelectedIndex = -1;
            dtpTime.Value = DateTime.Today.AddHours(9);

            dgvClasses.ClearSelection();
            dgvSchedules.ClearSelection();

            _currentContext = SelectionContext.None;
            SetButtonStates(SelectionContext.None);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashBord dash = new DashBord();
            dash.FormClosed += (s, args) => Application.Exit();
            dash.Show();
            this.Hide();
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            // validation
            if (_selectedClassID == -1)
            {
                MessageBox.Show("Please select a class from the table to delete.");
                return;
            }

            // confirmation
            if (MessageBox.Show(
                "Are you sure you want to delete this class?\n\nThis will also delete ALL its schedules.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    //  Delete all schedules for this class (CHILD FIRST)
                    SqlCommand cmdSchedules = new SqlCommand(
                        "DELETE FROM Class_Schedule WHERE Class_ID = @id", con);
                    cmdSchedules.Parameters.AddWithValue("@id", _selectedClassID);
                    cmdSchedules.ExecuteNonQuery();

                    // Delete the class itself (PARENT)
                    SqlCommand cmdClass = new SqlCommand(
                        "DELETE FROM Class WHERE ID = @id", con);
                    cmdClass.Parameters.AddWithValue("@id", _selectedClassID);
                    cmdClass.ExecuteNonQuery();

                    MessageBox.Show("Class and all its schedules deleted successfully!");

                    //  Refresh UI
                    LoadClassData();
                    LoadScheduleData(); // Show all schedules again
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    MessageBox.Show("Cannot delete: This class is referenced in another table (e.g., Offers).");
                else
                    MessageBox.Show($"Database Error ({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            // Capture values BEFORE any operations
            int classId = _selectedClassID;
            string day = _selectedScheduleDay;
            string time = _selectedScheduleTime;

            // validation
            if (classId == -1)
            {
                MessageBox.Show("Please select a class first.");
                return;
            }
            if (string.IsNullOrEmpty(day) || string.IsNullOrEmpty(time))
            {
                MessageBox.Show("Please select a specific schedule from the bottom table to delete.");
                return;
            }

            // confirmation
            if (MessageBox.Show(
                $"Delete schedule for {day} at {time}?\n\nThis will NOT delete the class itself.",
                "Confirm Delete Schedule",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    string query = @"DELETE FROM Class_Schedule 
                             WHERE Class_ID = @cid AND Day = @day AND Time = @time";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cid", classId);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@time", time);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Schedule deleted successfully!");

                        //  clear state to prevent double-delete
                        _selectedScheduleDay = "";
                        _selectedScheduleTime = "";

                        // Refresh schedule grid
                        LoadScheduleData(classId);

                        // Clear schedule input fields
                        cmbDay.SelectedIndex = -1;

                        // Keep class selection active
                        SetButtonStates(SelectionContext.Class);
                    }
                    else
                    {
                        MessageBox.Show("Schedule not found. It may have already been deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            //validation
            if (_selectedClassID == -1)
            {
                MessageBox.Show("Please select a class from the table to update.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClassName.Text))
            {
                MessageBox.Show("Class name cannot be empty.");
                return;
            }
            if (cmbTrainer.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a trainer.");
                return;
            }

            // confirmation
            if (MessageBox.Show(
                "Update this class with the new details?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(DBconnection.ConnectionString))
                {
                    con.Open();

                    // update class (Name and Trainer only)
                    string query = @"UPDATE Class 
                             SET Name = @name, 
                                 Trainer_ID = @tid 
                             WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                    cmd.Parameters.AddWithValue("@tid", cmbTrainer.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", _selectedClassID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Class updated successfully!");

                        // refresh ui
                        LoadClassData();

                        // Keep class selected but refresh its display
                        SetButtonStates(SelectionContext.Class);
                    }
                    else
                    {
                        MessageBox.Show("No changes were made. The class may have already been updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update Error: {ex.Message}");
            }
        }
    }
}
