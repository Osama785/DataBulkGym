namespace Gym_Management
{
    partial class Member
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Member));
            label2 = new Label();
            txtFname = new TextBox();
            label3 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            txtLname = new TextBox();
            label4 = new Label();
            Gender = new ComboBox();
            label5 = new Label();
            comboBoxMembership = new ComboBox();
            label7 = new Label();
            dateStart = new MonthCalendar();
            label8 = new Label();
            comboBoxBranch = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            comboBoxPlan = new ComboBox();
            label11 = new Label();
            txtPhone = new TextBox();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            Add_Member = new Button();
            Update_Member = new Button();
            Delete_Member = new Button();
            Search = new Button();
            Back = new Button();
            Add_Phone = new Button();
            label1 = new Label();
            txtID = new TextBox();
            dataGridView2 = new DataGridView();
            Delete_Phone = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label2.Location = new Point(71, 204);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 1;
            label2.Text = " First Name ";
            label2.Click += label2_Click;
            // 
            // txtFname
            // 
            txtFname.Anchor = AnchorStyles.None;
            txtFname.Location = new Point(177, 201);
            txtFname.Name = "txtFname";
            txtFname.Size = new Size(222, 27);
            txtFname.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label3.Location = new Point(78, 258);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 3;
            label3.Text = "Last Name ";
            label3.Click += label3_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // txtLname
            // 
            txtLname.Anchor = AnchorStyles.None;
            txtLname.Location = new Point(177, 255);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(222, 27);
            txtLname.TabIndex = 4;
            txtLname.TextChanged += textBox1_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 427);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 5;
            label4.Click += label4_Click;
            // 
            // Gender
            // 
            Gender.Anchor = AnchorStyles.None;
            Gender.FormattingEnabled = true;
            Gender.Items.AddRange(new object[] { "Male", "Female" });
            Gender.Location = new Point(177, 303);
            Gender.Name = "Gender";
            Gender.Size = new Size(222, 28);
            Gender.TabIndex = 7;
            Gender.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label5.Location = new Point(91, 306);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 8;
            label5.Text = "Gender";
            label5.Click += label5_Click;
            // 
            // comboBoxMembership
            // 
            comboBoxMembership.Anchor = AnchorStyles.None;
            comboBoxMembership.FormattingEnabled = true;
            comboBoxMembership.Location = new Point(177, 353);
            comboBoxMembership.Name = "comboBoxMembership";
            comboBoxMembership.Size = new Size(222, 28);
            comboBoxMembership.TabIndex = 11;
            comboBoxMembership.SelectedIndexChanged += comboBoxMembership_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label7.Location = new Point(71, 360);
            label7.Name = "label7";
            label7.Size = new Size(100, 21);
            label7.TabIndex = 12;
            label7.Text = "MemberShip";
            label7.Click += label7_Click;
            // 
            // dateStart
            // 
            dateStart.Anchor = AnchorStyles.None;
            dateStart.Location = new Point(557, 201);
            dateStart.Name = "dateStart";
            dateStart.TabIndex = 13;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label8.Location = new Point(598, 171);
            label8.Name = "label8";
            label8.Size = new Size(173, 21);
            label8.TabIndex = 14;
            label8.Text = "Membership Start Date";
            // 
            // comboBoxBranch
            // 
            comboBoxBranch.Anchor = AnchorStyles.None;
            comboBoxBranch.FormattingEnabled = true;
            comboBoxBranch.Location = new Point(177, 407);
            comboBoxBranch.Name = "comboBoxBranch";
            comboBoxBranch.Size = new Size(222, 28);
            comboBoxBranch.TabIndex = 15;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label9.Location = new Point(91, 407);
            label9.Name = "label9";
            label9.Size = new Size(58, 21);
            label9.TabIndex = 16;
            label9.Text = "Branch";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label10.Location = new Point(101, 457);
            label10.Name = "label10";
            label10.Size = new Size(40, 21);
            label10.TabIndex = 17;
            label10.Text = "Plan";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.Anchor = AnchorStyles.None;
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(177, 457);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(222, 28);
            comboBoxPlan.TabIndex = 18;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label11.Location = new Point(98, 505);
            label11.Name = "label11";
            label11.Size = new Size(54, 21);
            label11.TabIndex = 19;
            label11.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.None;
            txtPhone.BackColor = SystemColors.Window;
            txtPhone.Location = new Point(177, 505);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(222, 27);
            txtPhone.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 616);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(888, 187);
            dataGridView1.TabIndex = 21;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(341, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 180);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Add_Member
            // 
            Add_Member.Anchor = AnchorStyles.None;
            Add_Member.Location = new Point(598, 420);
            Add_Member.Name = "Add_Member";
            Add_Member.Size = new Size(170, 29);
            Add_Member.TabIndex = 24;
            Add_Member.Text = "Add Member";
            Add_Member.UseVisualStyleBackColor = true;
            Add_Member.Click += Add_Member_Click;
            // 
            // Update_Member
            // 
            Update_Member.Anchor = AnchorStyles.None;
            Update_Member.Location = new Point(598, 561);
            Update_Member.Name = "Update_Member";
            Update_Member.Size = new Size(170, 29);
            Update_Member.TabIndex = 25;
            Update_Member.Text = "Update Member";
            Update_Member.UseVisualStyleBackColor = true;
            Update_Member.Click += Update_Member_Click;
            // 
            // Delete_Member
            // 
            Delete_Member.Anchor = AnchorStyles.None;
            Delete_Member.Location = new Point(598, 517);
            Delete_Member.Name = "Delete_Member";
            Delete_Member.Size = new Size(170, 29);
            Delete_Member.TabIndex = 26;
            Delete_Member.Text = "Delete Member";
            Delete_Member.UseVisualStyleBackColor = true;
            Delete_Member.Click += Delete_Member_Click;
            // 
            // Search
            // 
            Search.Anchor = AnchorStyles.None;
            Search.Location = new Point(598, 466);
            Search.Name = "Search";
            Search.Size = new Size(170, 29);
            Search.TabIndex = 27;
            Search.Text = "Search For Member";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // Back
            // 
            Back.Anchor = AnchorStyles.None;
            Back.BackColor = Color.DarkTurquoise;
            Back.Location = new Point(730, 12);
            Back.Name = "Back";
            Back.Size = new Size(114, 29);
            Back.TabIndex = 28;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = false;
            Back.Click += Back_Click;
            // 
            // Add_Phone
            // 
            Add_Phone.Anchor = AnchorStyles.None;
            Add_Phone.Location = new Point(497, 865);
            Add_Phone.Name = "Add_Phone";
            Add_Phone.Size = new Size(110, 29);
            Add_Phone.TabIndex = 29;
            Add_Phone.Text = "Add Phone";
            Add_Phone.UseVisualStyleBackColor = true;
            Add_Phone.Click += Add_Phone_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label1.Location = new Point(117, 561);
            label1.Name = "label1";
            label1.Size = new Size(24, 21);
            label1.TabIndex = 30;
            label1.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.None;
            txtID.BackColor = SystemColors.Window;
            txtID.Location = new Point(177, 558);
            txtID.Name = "txtID";
            txtID.Size = new Size(222, 27);
            txtID.TabIndex = 31;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.None;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1, 809);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(274, 143);
            dataGridView2.TabIndex = 32;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Delete_Phone
            // 
            Delete_Phone.Location = new Point(497, 900);
            Delete_Phone.Name = "Delete_Phone";
            Delete_Phone.Size = new Size(110, 29);
            Delete_Phone.TabIndex = 33;
            Delete_Phone.Text = "Delete Phone";
            Delete_Phone.UseVisualStyleBackColor = true;
            Delete_Phone.Click += Delete_Phone_Click;
            // 
            // Member
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(879, 953);
            Controls.Add(Delete_Phone);
            Controls.Add(dataGridView2);
            Controls.Add(txtID);
            Controls.Add(label1);
            Controls.Add(Add_Phone);
            Controls.Add(Back);
            Controls.Add(Search);
            Controls.Add(Delete_Member);
            Controls.Add(Update_Member);
            Controls.Add(Add_Member);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(txtPhone);
            Controls.Add(label11);
            Controls.Add(comboBoxPlan);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(comboBoxBranch);
            Controls.Add(label8);
            Controls.Add(dateStart);
            Controls.Add(label7);
            Controls.Add(comboBoxMembership);
            Controls.Add(label5);
            Controls.Add(Gender);
            Controls.Add(label4);
            Controls.Add(txtLname);
            Controls.Add(label3);
            Controls.Add(txtFname);
            Controls.Add(label2);
            Name = "Member";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Member Mangment";
            Load += Member_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtFname;
        private Label label3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox txtLname;
        private Label label4;
        private ComboBox Gender;
        private Label label5;
        private ComboBox comboBoxMembership;
        private Label label7;
        private MonthCalendar dateStart;
        private Label label8;
        private ComboBox comboBoxBranch;
        private Label label9;
        private Label label10;
        private ComboBox comboBoxPlan;
        private Label label11;
        private TextBox txtPhone;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Button Add_Member;
        private Button Update_Member;
        private Button Delete_Member;
        private Button Search;
        private Button Back;
        private Button Add_Phone;
        private Label label1;
        private TextBox txtID;
        private DataGridView dataGridView2;
        private Button Delete_Phone;
    }
}