namespace Gym_Management
{
    partial class Branch
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvBranch;
        private DataGridView dgvOffers;
        private DataGridView dgvEquipment;

        private TextBox txtCity;
        private TextBox txtArea;
        private TextBox txtManagerFname;
        private TextBox txtManagerLname;
        private TextBox txtManagerPhone;

        private Label lblBranchType, lblCity, lblArea, lblFname, lblLname, lblPhone;
        private ComboBox comboType;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAddEquipment;

        private TextBox txtEquipName;
        private TextBox txtEquipDuration;
        private DateTimePicker dtPurchaseDate;

        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvBranch = new DataGridView();
            dgvOffers = new DataGridView();
            dgvEquipment = new DataGridView();
            txtCity = new TextBox();
            txtArea = new TextBox();
            txtManagerFname = new TextBox();
            txtManagerLname = new TextBox();
            txtManagerPhone = new TextBox();
            lblBranchType = new Label();
            lblCity = new Label();
            lblArea = new Label();
            lblFname = new Label();
            lblLname = new Label();
            lblPhone = new Label();
            comboType = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtEquipName = new TextBox();
            dtPurchaseDate = new DateTimePicker();
            txtEquipDuration = new TextBox();
            btnAddEquipment = new Button();
            btnUpdateEquipment = new Button();
            btnDeleteEquipment = new Button();
            btnBack = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBranch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
            this.BackColor = Color.FromArgb(144, 169, 197);
            SuspendLayout();
            
            dgvBranch.Location = new Point(20, 100);
            dgvBranch.Name = "dgvBranch";
            dgvBranch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBranch.Size = new Size(863, 200);
            dgvBranch.TabIndex = 15;
            dgvBranch.CellClick += dgvBranch_CellClick;
       
            dgvOffers.Location = new Point(20, 320);
            dgvOffers.Name = "dgvOffers";
            dgvOffers.Size = new Size(222, 250);
            dgvOffers.TabIndex = 16;

            dgvEquipment.Location = new Point(260, 320);
            dgvEquipment.Name = "dgvEquipment";
            dgvEquipment.Size = new Size(543, 250);
            dgvEquipment.TabIndex = 17;
            dgvEquipment.CellClick += dgvEquipment_CellClick;

            txtCity.Location = new Point(160, 20);
            txtCity.Name = "txtCity";
            txtCity.PlaceholderText = "City";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 1;

            txtArea.Location = new Point(300, 20);
            txtArea.Name = "txtArea";
            txtArea.PlaceholderText = "Area";
            txtArea.Size = new Size(100, 23);
            txtArea.TabIndex = 2;

            txtManagerFname.Location = new Point(440, 20);
            txtManagerFname.Name = "txtManagerFname";
            txtManagerFname.PlaceholderText = "First Name";
            txtManagerFname.Size = new Size(100, 23);
            txtManagerFname.TabIndex = 3;

            txtManagerLname.Location = new Point(600, 20);
            txtManagerLname.Name = "txtManagerLname";
            txtManagerLname.PlaceholderText = "Last Name";
            txtManagerLname.Size = new Size(100, 23);
            txtManagerLname.TabIndex = 4;
           
            txtManagerPhone.Location = new Point(760, 20);
            txtManagerPhone.Name = "txtManagerPhone";
            txtManagerPhone.PlaceholderText = "Phone";
            txtManagerPhone.Size = new Size(100, 23);
            txtManagerPhone.TabIndex = 5;
           
            lblBranchType.AutoSize = true;
            lblBranchType.Location = new Point(20, 4);
            lblBranchType.Name = "lblBranchType";
            lblBranchType.Size = new Size(74, 15);
            lblBranchType.TabIndex = 6;
            lblBranchType.Text = "Branch Type:";
            
            lblCity.Location = new Point(0, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(100, 23);
            lblCity.TabIndex = 7;
            
            lblArea.Location = new Point(0, 0);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(100, 23);
            lblArea.TabIndex = 8;
           
            lblFname.Location = new Point(0, 0);
            lblFname.Name = "lblFname";
            lblFname.Size = new Size(100, 23);
            lblFname.TabIndex = 9;
            
            lblLname.Location = new Point(0, 0);
            lblLname.Name = "lblLname";
            lblLname.Size = new Size(100, 23);
            lblLname.TabIndex = 10;
             
            lblPhone.Location = new Point(0, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 23);
            lblPhone.TabIndex = 11;
            
            comboType.Location = new Point(20, 20);
            comboType.Name = "comboType";
            comboType.Size = new Size(120, 23);
            comboType.TabIndex = 0;
            
            btnAdd.Location = new Point(160, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            
            btnUpdate.Location = new Point(260, 60);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            
            btnDelete.Location = new Point(361, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            
            txtEquipName.Location = new Point(820, 320);
            txtEquipName.Name = "txtEquipName";
            txtEquipName.PlaceholderText = "Equipment Name";
            txtEquipName.Size = new Size(100, 23);
            txtEquipName.TabIndex = 20;
           
            dtPurchaseDate.Location = new Point(820, 375);
            dtPurchaseDate.Name = "dtPurchaseDate";
            dtPurchaseDate.Size = new Size(200, 23);
            dtPurchaseDate.TabIndex = 21;
            
            txtEquipDuration.Location = new Point(820, 416);
            txtEquipDuration.Name = "txtEquipDuration";
            txtEquipDuration.PlaceholderText = "Maintenance Duration";
            txtEquipDuration.Size = new Size(128, 23);
            txtEquipDuration.TabIndex = 22;
                        btnAddEquipment.Location = new Point(820, 455);
            btnAddEquipment.Name = "btnAddEquipment";
            btnAddEquipment.Size = new Size(75, 23);
            btnAddEquipment.TabIndex = 23;
            btnAddEquipment.Text = "Add Equipment";
            btnAddEquipment.Click += btnAddEquipment_Click;
            
            btnUpdateEquipment.Location = new Point(820, 495);
            btnUpdateEquipment.Name = "btnUpdateEquipment";
            btnUpdateEquipment.Size = new Size(75, 23);
            btnUpdateEquipment.TabIndex = 18;
            btnUpdateEquipment.Text = "Update Equipment";
            btnUpdateEquipment.Click += btnUpdateEquipment_Click;
            
            btnDeleteEquipment.Location = new Point(820, 535);
            btnDeleteEquipment.Name = "btnDeleteEquipment";
            btnDeleteEquipment.Size = new Size(75, 23);
            btnDeleteEquipment.TabIndex = 19;
            btnDeleteEquipment.Text = "Delete Equipment";
            btnDeleteEquipment.Click += btnDeleteEquipment_Click;
            
            label1.AutoSize = true;
            label1.Location = new Point(820, 357);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 24;
            label1.Text = "Purchase Date";
            label1.Click += label1_Click;

            btnBack.Location = new Point(1050, 20); 
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 50;
            btnBack.Text = "Back";
            btnBack.BackColor = Color.DarkCyan;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Click += btnBack_Click;
            this.Controls.Add(btnBack);

            ApplyGridTheme(dgvBranch);
            ApplyGridTheme(dgvOffers);
            ApplyGridTheme(dgvEquipment);

            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(comboType);
            Controls.Add(txtCity);
            Controls.Add(txtArea);
            Controls.Add(txtManagerFname);
            Controls.Add(txtManagerLname);
            Controls.Add(txtManagerPhone);
            Controls.Add(lblBranchType);
            Controls.Add(lblCity);
            Controls.Add(lblArea);
            Controls.Add(lblFname);
            Controls.Add(lblLname);
            Controls.Add(lblPhone);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(dgvBranch);
            Controls.Add(dgvOffers);
            Controls.Add(dgvEquipment);
            Controls.Add(btnUpdateEquipment);
            Controls.Add(btnDeleteEquipment);
            Controls.Add(txtEquipName);
            Controls.Add(dtPurchaseDate);
            Controls.Add(txtEquipDuration);
            Controls.Add(btnAddEquipment);
            Name = "Branch";
            Text = "Branch Management";
            Load += Branch_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBranch).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnUpdateEquipment;
        private Button btnDeleteEquipment;
        private Label label1;
        private void ApplyGridTheme(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 35, 81); 
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 235, 245);
        }
    }
}