namespace Gym_Management
{
    partial class Trainers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trainers));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageTrainers = new System.Windows.Forms.TabPage();
            this.tabPageWorkoutPlans = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxShift = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxSpeciality = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxBranch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Add_Trainer = new System.Windows.Forms.Button();
            this.Update_Trainer = new System.Windows.Forms.Button();
            this.Delete_Trainer = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Clear_Fields = new System.Windows.Forms.Button();
            this.labelWP_Name = new System.Windows.Forms.Label();
            this.comboBoxWP_Name = new System.Windows.Forms.ComboBox();
            this.labelWP_Duration = new System.Windows.Forms.Label();
            this.txtWP_Duration = new System.Windows.Forms.TextBox();
            this.labelWP_Intensity = new System.Windows.Forms.Label();
            this.comboBoxWP_Intensity = new System.Windows.Forms.ComboBox();
            this.labelWP_Trainer = new System.Windows.Forms.Label();
            this.txtWP_TrainerInfo = new System.Windows.Forms.TextBox();
            this.Add_Plan = new System.Windows.Forms.Button();
            this.Delete_Plan = new System.Windows.Forms.Button();
            this.Search_Plan = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageTrainers.SuspendLayout();
            this.tabPageWorkoutPlans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            this.tabControlMain.Controls.Add(this.tabPageTrainers);
            this.tabControlMain.Controls.Add(this.tabPageWorkoutPlans);
            this.tabControlMain.Location = new System.Drawing.Point(12, 60);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(860, 580);
            this.tabControlMain.TabIndex = 0;

            this.tabPageTrainers.Controls.Add(this.label2);
            this.tabPageTrainers.Controls.Add(this.txtFname);
            this.tabPageTrainers.Controls.Add(this.label3);
            this.tabPageTrainers.Controls.Add(this.txtLname);
            this.tabPageTrainers.Controls.Add(this.label5);
            this.tabPageTrainers.Controls.Add(this.comboBoxGender);
            this.tabPageTrainers.Controls.Add(this.label6);
            this.tabPageTrainers.Controls.Add(this.comboBoxShift);
            this.tabPageTrainers.Controls.Add(this.label7);
            this.tabPageTrainers.Controls.Add(this.comboBoxSpeciality);
            this.tabPageTrainers.Controls.Add(this.label9);
            this.tabPageTrainers.Controls.Add(this.comboBoxBranch);
            this.tabPageTrainers.Controls.Add(this.label11);
            this.tabPageTrainers.Controls.Add(this.txtPhone);
            this.tabPageTrainers.Controls.Add(this.label1);
            this.tabPageTrainers.Controls.Add(this.txtID);
            this.tabPageTrainers.Controls.Add(this.Add_Trainer);
            this.tabPageTrainers.Controls.Add(this.Update_Trainer);
            this.tabPageTrainers.Controls.Add(this.Search);
            this.tabPageTrainers.Controls.Add(this.Delete_Trainer);
            this.tabPageTrainers.Controls.Add(this.Clear_Fields);
            this.tabPageTrainers.Controls.Add(this.dataGridView1);
            this.tabPageTrainers.Location = new System.Drawing.Point(4, 29);
            this.tabPageTrainers.Name = "tabPageTrainers";
            this.tabPageTrainers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrainers.Size = new System.Drawing.Size(852, 547);
            this.tabPageTrainers.TabIndex = 0;
            this.tabPageTrainers.Text = "Manage Trainers";
            this.tabPageTrainers.BackColor = System.Drawing.SystemColors.ActiveCaption;

            this.tabPageWorkoutPlans.Controls.Add(this.labelWP_Name);
            this.tabPageWorkoutPlans.Controls.Add(this.comboBoxWP_Name);
            this.tabPageWorkoutPlans.Controls.Add(this.labelWP_Duration);
            this.tabPageWorkoutPlans.Controls.Add(this.txtWP_Duration);
            this.tabPageWorkoutPlans.Controls.Add(this.labelWP_Intensity);
            this.tabPageWorkoutPlans.Controls.Add(this.comboBoxWP_Intensity);
            this.tabPageWorkoutPlans.Controls.Add(this.labelWP_Trainer);
            this.tabPageWorkoutPlans.Controls.Add(this.txtWP_TrainerInfo);
            this.tabPageWorkoutPlans.Controls.Add(this.Add_Plan);
            this.tabPageWorkoutPlans.Controls.Add(this.Delete_Plan);
            this.tabPageWorkoutPlans.Controls.Add(this.Search_Plan);
            this.tabPageWorkoutPlans.Controls.Add(this.dataGridView2);
            this.tabPageWorkoutPlans.Location = new System.Drawing.Point(4, 29);
            this.tabPageWorkoutPlans.Name = "tabPageWorkoutPlans";
            this.tabPageWorkoutPlans.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorkoutPlans.Size = new System.Drawing.Size(852, 547);
            this.tabPageWorkoutPlans.TabIndex = 1;
            this.tabPageWorkoutPlans.Text = "Manage Workout Plans";
            this.tabPageWorkoutPlans.BackColor = System.Drawing.SystemColors.ActiveCaption;

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";

            this.txtFname.Location = new System.Drawing.Point(110, 20);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(200, 27);
            this.txtFname.TabIndex = 2;

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";

            this.txtLname.Location = new System.Drawing.Point(110, 60);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(200, 27);
            this.txtLname.TabIndex = 4;

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Gender";

            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Location = new System.Drawing.Point(110, 100);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(200, 28);
            this.comboBoxGender.TabIndex = 6;

            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Shift";

            this.comboBoxShift.FormattingEnabled = true;
            this.comboBoxShift.Location = new System.Drawing.Point(110, 140);
            this.comboBoxShift.Name = "comboBoxShift";
            this.comboBoxShift.Size = new System.Drawing.Size(200, 28);
            this.comboBoxShift.TabIndex = 8;

            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Speciality";

            this.comboBoxSpeciality.FormattingEnabled = true;
            this.comboBoxSpeciality.Location = new System.Drawing.Point(420, 20);
            this.comboBoxSpeciality.Name = "comboBoxSpeciality";
            this.comboBoxSpeciality.Size = new System.Drawing.Size(200, 28);
            this.comboBoxSpeciality.TabIndex = 10;

            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Branch";

            this.comboBoxBranch.FormattingEnabled = true;
            this.comboBoxBranch.Location = new System.Drawing.Point(420, 60);
            this.comboBoxBranch.Name = "comboBoxBranch";
            this.comboBoxBranch.Size = new System.Drawing.Size(200, 28);
            this.comboBoxBranch.TabIndex = 12;

            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Phone";

            this.txtPhone.Location = new System.Drawing.Point(420, 100);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 27);
            this.txtPhone.TabIndex = 14;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "ID";

            this.txtID.Location = new System.Drawing.Point(420, 140);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 27);
            this.txtID.TabIndex = 16;

            this.Add_Trainer.Location = new System.Drawing.Point(660, 20);
            this.Add_Trainer.Name = "Add_Trainer";
            this.Add_Trainer.Size = new System.Drawing.Size(160, 30);
            this.Add_Trainer.TabIndex = 18;
            this.Add_Trainer.Text = "Add Trainer";
            this.Add_Trainer.UseVisualStyleBackColor = true;
            this.Add_Trainer.Click += new System.EventHandler(this.Add_Trainer_Click);

            this.Search.Location = new System.Drawing.Point(660, 60);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(160, 30);
            this.Search.TabIndex = 19;
            this.Search.Text = "Search For Trainer";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);

            this.Update_Trainer.Location = new System.Drawing.Point(660, 100);
            this.Update_Trainer.Name = "Update_Trainer";
            this.Update_Trainer.Size = new System.Drawing.Size(160, 30);
            this.Update_Trainer.TabIndex = 20;
            this.Update_Trainer.Text = "Update Trainer";
            this.Update_Trainer.UseVisualStyleBackColor = true;
            this.Update_Trainer.Click += new System.EventHandler(this.Update_Trainer_Click);

            this.Delete_Trainer.Location = new System.Drawing.Point(660, 140);
            this.Delete_Trainer.Name = "Delete_Trainer";
            this.Delete_Trainer.Size = new System.Drawing.Size(160, 30);
            this.Delete_Trainer.TabIndex = 21;
            this.Delete_Trainer.Text = "Delete Trainer";
            this.Delete_Trainer.UseVisualStyleBackColor = true;
            this.Delete_Trainer.Click += new System.EventHandler(this.Delete_Trainer_Click);

            this.Clear_Fields.Location = new System.Drawing.Point(660, 180);
            this.Clear_Fields.Name = "Clear_Fields";
            this.Clear_Fields.Size = new System.Drawing.Size(160, 30);
            this.Clear_Fields.TabIndex = 24;
            this.Clear_Fields.Text = "Clear Fields";
            this.Clear_Fields.UseVisualStyleBackColor = true;
            this.Clear_Fields.Click += new System.EventHandler(this.Clear_Fields_Click);

            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(800, 300);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            this.labelWP_Name.AutoSize = true;
            this.labelWP_Name.Location = new System.Drawing.Point(20, 23);
            this.labelWP_Name.Name = "labelWP_Name";
            this.labelWP_Name.Size = new System.Drawing.Size(82, 20);
            this.labelWP_Name.TabIndex = 26;
            this.labelWP_Name.Text = "Plan Name";

            this.comboBoxWP_Name.FormattingEnabled = true;
            this.comboBoxWP_Name.Location = new System.Drawing.Point(150, 20);
            this.comboBoxWP_Name.Name = "comboBoxWP_Name";
            this.comboBoxWP_Name.Size = new System.Drawing.Size(200, 28);
            this.comboBoxWP_Name.TabIndex = 27;

            this.labelWP_Duration.AutoSize = true;
            this.labelWP_Duration.Location = new System.Drawing.Point(20, 63);
            this.labelWP_Duration.Name = "labelWP_Duration";
            this.labelWP_Duration.Size = new System.Drawing.Size(122, 20);
            this.labelWP_Duration.TabIndex = 28;
            this.labelWP_Duration.Text = "Duration (weeks)";

            this.txtWP_Duration.Location = new System.Drawing.Point(150, 60);
            this.txtWP_Duration.Name = "txtWP_Duration";
            this.txtWP_Duration.Size = new System.Drawing.Size(200, 27);
            this.txtWP_Duration.TabIndex = 29;

            this.labelWP_Intensity.AutoSize = true;
            this.labelWP_Intensity.Location = new System.Drawing.Point(380, 23);
            this.labelWP_Intensity.Name = "labelWP_Intensity";
            this.labelWP_Intensity.Size = new System.Drawing.Size(100, 20);
            this.labelWP_Intensity.TabIndex = 30;
            this.labelWP_Intensity.Text = "Intensity Level";

            this.comboBoxWP_Intensity.FormattingEnabled = true;
            this.comboBoxWP_Intensity.Location = new System.Drawing.Point(490, 20);
            this.comboBoxWP_Intensity.Name = "comboBoxWP_Intensity";
            this.comboBoxWP_Intensity.Size = new System.Drawing.Size(200, 28);
            this.comboBoxWP_Intensity.TabIndex = 31;

            this.labelWP_Trainer.AutoSize = true;
            this.labelWP_Trainer.Location = new System.Drawing.Point(380, 63);
            this.labelWP_Trainer.Name = "labelWP_Trainer";
            this.labelWP_Trainer.Size = new System.Drawing.Size(54, 20);
            this.labelWP_Trainer.TabIndex = 32;
            this.labelWP_Trainer.Text = "Trainer";

            this.txtWP_TrainerInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtWP_TrainerInfo.Location = new System.Drawing.Point(490, 60);
            this.txtWP_TrainerInfo.Name = "txtWP_TrainerInfo";
            this.txtWP_TrainerInfo.ReadOnly = true;
            this.txtWP_TrainerInfo.Size = new System.Drawing.Size(200, 27);
            this.txtWP_TrainerInfo.TabIndex = 33;

            this.Add_Plan.Location = new System.Drawing.Point(710, 20);
            this.Add_Plan.Name = "Add_Plan";
            this.Add_Plan.Size = new System.Drawing.Size(120, 30);
            this.Add_Plan.TabIndex = 34;
            this.Add_Plan.Text = "Add Plan";
            this.Add_Plan.UseVisualStyleBackColor = true;
            this.Add_Plan.Click += new System.EventHandler(this.Add_Plan_Click);

            this.Delete_Plan.Location = new System.Drawing.Point(710, 60);
            this.Delete_Plan.Name = "Delete_Plan";
            this.Delete_Plan.Size = new System.Drawing.Size(120, 30);
            this.Delete_Plan.TabIndex = 35;
            this.Delete_Plan.Text = "Delete Plan";
            this.Delete_Plan.UseVisualStyleBackColor = true;
            this.Delete_Plan.Click += new System.EventHandler(this.Delete_Plan_Click);

            this.Search_Plan.Location = new System.Drawing.Point(710, 100);
            this.Search_Plan.Name = "Search_Plan";
            this.Search_Plan.Size = new System.Drawing.Size(120, 30);
            this.Search_Plan.TabIndex = 36;
            this.Search_Plan.Text = "Search Plan";
            this.Search_Plan.UseVisualStyleBackColor = true;
            this.Search_Plan.Click += new System.EventHandler(this.Search_Plan_Click);

            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 150);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(810, 380);
            this.dataGridView2.TabIndex = 37;

            this.Back.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Back.Location = new System.Drawing.Point(758, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(114, 35);
            this.Back.TabIndex = 22;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);

            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Trainers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trainers Management";
            this.Load += new System.EventHandler(this.Trainers_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageTrainers.ResumeLayout(false);
            this.tabPageTrainers.PerformLayout();
            this.tabPageWorkoutPlans.ResumeLayout(false);
            this.tabPageWorkoutPlans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTrainers;
        private System.Windows.Forms.TabPage tabPageWorkoutPlans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.ComboBox comboBoxShift;
        private System.Windows.Forms.ComboBox comboBoxSpeciality;
        private System.Windows.Forms.ComboBox comboBoxBranch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Add_Trainer;
        private System.Windows.Forms.Button Update_Trainer;
        private System.Windows.Forms.Button Delete_Trainer;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Clear_Fields;
        private System.Windows.Forms.Label labelWP_Name;
        private System.Windows.Forms.ComboBox comboBoxWP_Name;
        private System.Windows.Forms.Label labelWP_Duration;
        private System.Windows.Forms.TextBox txtWP_Duration;
        private System.Windows.Forms.Label labelWP_Intensity;
        private System.Windows.Forms.ComboBox comboBoxWP_Intensity;
        private System.Windows.Forms.Label labelWP_Trainer;
        private System.Windows.Forms.TextBox txtWP_TrainerInfo;
        private System.Windows.Forms.Button Add_Plan;
        private System.Windows.Forms.Button Delete_Plan;
        private System.Windows.Forms.Button Search_Plan;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}