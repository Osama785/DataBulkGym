namespace Gym_Management
{
    partial class ClassScheduler
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
            txtClassName = new TextBox();
            cmbTrainer = new ComboBox();
            cmbDay = new ComboBox();
            dtpTime = new DateTimePicker();
            dgvClasses = new DataGridView();
            dgvSchedules = new DataGridView();
            btnAddClass = new Button();
            btnUpdateClass = new Button();
            btnDeleteClass = new Button();
            btnClear = new Button();
            btnBack = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnDeleteSchedule = new Button();
            btnAddScheduleOnly = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).BeginInit();
            SuspendLayout();
            // 
            // txtClassName
            // 
            txtClassName.ForeColor = SystemColors.ScrollBar;
            txtClassName.Location = new Point(203, 62);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(197, 27);
            txtClassName.TabIndex = 0;
            // 
            // cmbTrainer
            // 
            cmbTrainer.ForeColor = SystemColors.ScrollBar;
            cmbTrainer.FormattingEnabled = true;
            cmbTrainer.Location = new Point(203, 123);
            cmbTrainer.Name = "cmbTrainer";
            cmbTrainer.Size = new Size(197, 28);
            cmbTrainer.TabIndex = 1;
            cmbTrainer.SelectedIndexChanged += cmbTrainer_SelectedIndexChanged;
            // 
            // cmbDay
            // 
            cmbDay.ForeColor = SystemColors.ScrollBar;
            cmbDay.FormattingEnabled = true;
            cmbDay.Location = new Point(583, 64);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(197, 28);
            cmbDay.TabIndex = 2;
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(583, 123);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(197, 27);
            dtpTime.TabIndex = 3;
            // 
            // dgvClasses
            // 
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.BackgroundColor = SystemColors.ButtonHighlight;
            dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasses.Location = new Point(29, 186);
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersWidth = 51;
            dgvClasses.Size = new Size(443, 254);
            dgvClasses.TabIndex = 4;
            // 
            // dgvSchedules
            // 
            dgvSchedules.AllowUserToAddRows = false;
            dgvSchedules.BackgroundColor = SystemColors.ButtonHighlight;
            dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedules.Location = new Point(503, 186);
            dgvSchedules.Name = "dgvSchedules";
            dgvSchedules.ReadOnly = true;
            dgvSchedules.RowHeadersWidth = 51;
            dgvSchedules.Size = new Size(443, 254);
            dgvSchedules.TabIndex = 5;
            // 
            // btnAddClass
            // 
            btnAddClass.Location = new Point(849, 66);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(94, 29);
            btnAddClass.TabIndex = 6;
            btnAddClass.Text = "Add Class";
            btnAddClass.UseVisualStyleBackColor = true;
            // 
            // btnUpdateClass
            // 
            btnUpdateClass.Location = new Point(29, 466);
            btnUpdateClass.Name = "btnUpdateClass";
            btnUpdateClass.Size = new Size(126, 29);
            btnUpdateClass.TabIndex = 7;
            btnUpdateClass.Text = "Update Class";
            btnUpdateClass.UseVisualStyleBackColor = true;
            // 
            // btnDeleteClass
            // 
            btnDeleteClass.Location = new Point(329, 466);
            btnDeleteClass.Name = "btnDeleteClass";
            btnDeleteClass.Size = new Size(143, 29);
            btnDeleteClass.TabIndex = 8;
            btnDeleteClass.Text = "Delete Class";
            btnDeleteClass.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(852, 124);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.None;
            btnBack.BackColor = Color.DarkTurquoise;
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(114, 29);
            btnBack.TabIndex = 29;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label2.Location = new Point(87, 65);
            label2.Name = "label2";
            label2.Size = new Size(99, 21);
            label2.TabIndex = 30;
            label2.Text = " Class Name ";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label1.Location = new Point(127, 127);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 31;
            label1.Text = "Trainer";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label3.Location = new Point(529, 69);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 32;
            label3.Text = "Day";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 10.2F, FontStyle.Italic);
            label4.Location = new Point(523, 127);
            label4.Name = "label4";
            label4.Size = new Size(43, 21);
            label4.TabIndex = 33;
            label4.Text = "Time";
            label4.Click += label4_Click;
            // 
            // btnDeleteSchedule
            // 
            btnDeleteSchedule.Location = new Point(780, 466);
            btnDeleteSchedule.Name = "btnDeleteSchedule";
            btnDeleteSchedule.Size = new Size(163, 29);
            btnDeleteSchedule.TabIndex = 35;
            btnDeleteSchedule.Text = "Delete Schedule";
            btnDeleteSchedule.UseVisualStyleBackColor = true;
            // 
            // btnAddScheduleOnly
            // 
            btnAddScheduleOnly.Location = new Point(170, 466);
            btnAddScheduleOnly.Name = "btnAddScheduleOnly";
            btnAddScheduleOnly.Size = new Size(144, 29);
            btnAddScheduleOnly.TabIndex = 36;
            btnAddScheduleOnly.Text = "Add Schedule";
            btnAddScheduleOnly.UseVisualStyleBackColor = true;
            // 
            // ClassScheduler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(977, 511);
            Controls.Add(btnAddScheduleOnly);
            Controls.Add(btnDeleteSchedule);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteClass);
            Controls.Add(btnUpdateClass);
            Controls.Add(btnAddClass);
            Controls.Add(dgvSchedules);
            Controls.Add(dgvClasses);
            Controls.Add(dtpTime);
            Controls.Add(cmbDay);
            Controls.Add(cmbTrainer);
            Controls.Add(txtClassName);
            Name = "ClassScheduler";
            Text = "Form1";
            Load += ClassScheduler_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSchedules).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClassName;
        private ComboBox cmbTrainer;
        private ComboBox cmbDay;
        private DateTimePicker dtpTime;
        private DataGridView dgvClasses;
        private DataGridView dgvSchedules;
        private Button btnAddClass;
        private Button btnUpdateClass;
        private Button btnDeleteClass;
        private Button btnClear;
        private Button btnBack;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button btnDeleteSchedule;
        private Button btnAddScheduleOnly;
    }
}