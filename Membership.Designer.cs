namespace Gym_Management
{
    partial class Membership
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Membership));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            txtPrice = new TextBox();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            Back = new Button();
            Add_MemberShip = new Button();
            Update_MemberShip = new Button();
            Delete_MemberShip = new Button();
            Search = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(312, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 180);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 223);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 24;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 270);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 25;
            label2.Text = "Duration";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 320);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 26;
            label3.Text = "Price";
            // 
            // txtID
            // 
            txtID.Location = new Point(329, 216);
            txtID.Name = "txtID";
            txtID.Size = new Size(222, 27);
            txtID.TabIndex = 27;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(329, 313);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(222, 27);
            txtPrice.TabIndex = 28;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(329, 267);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 28);
            comboBox1.TabIndex = 29;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-3, 426);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(806, 187);
            dataGridView1.TabIndex = 30;
            // 
            // Back
            // 
            Back.Anchor = AnchorStyles.None;
            Back.BackColor = Color.DarkTurquoise;
            Back.Location = new Point(658, 43);
            Back.Name = "Back";
            Back.Size = new Size(114, 29);
            Back.TabIndex = 31;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = false;
            Back.Click += Back_Click;
            // 
            // Add_MemberShip
            // 
            Add_MemberShip.Location = new Point(85, 385);
            Add_MemberShip.Name = "Add_MemberShip";
            Add_MemberShip.Size = new Size(168, 29);
            Add_MemberShip.TabIndex = 32;
            Add_MemberShip.Text = "Add MemberShip";
            Add_MemberShip.UseVisualStyleBackColor = true;
            Add_MemberShip.Click += Add_MemberShip_Click;
            // 
            // Update_MemberShip
            // 
            Update_MemberShip.Location = new Point(256, 385);
            Update_MemberShip.Name = "Update_MemberShip";
            Update_MemberShip.Size = new Size(174, 29);
            Update_MemberShip.TabIndex = 33;
            Update_MemberShip.Text = "Update MemberShip";
            Update_MemberShip.UseVisualStyleBackColor = true;
            Update_MemberShip.Click += Update_MemberShip_Click;
            // 
            // Delete_MemberShip
            // 
            Delete_MemberShip.Location = new Point(436, 385);
            Delete_MemberShip.Name = "Delete_MemberShip";
            Delete_MemberShip.Size = new Size(168, 29);
            Delete_MemberShip.TabIndex = 34;
            Delete_MemberShip.Text = "Delete MemberShip";
            Delete_MemberShip.UseVisualStyleBackColor = true;
            Delete_MemberShip.Click += Delete_MemberShip_Click;
            // 
            // Search
            // 
            Search.Location = new Point(610, 385);
            Search.Name = "Search";
            Search.Size = new Size(94, 29);
            Search.TabIndex = 35;
            Search.Text = "Search";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // Membership
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 644);
            Controls.Add(Search);
            Controls.Add(Delete_MemberShip);
            Controls.Add(Update_MemberShip);
            Controls.Add(Add_MemberShip);
            Controls.Add(Back);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(txtPrice);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Membership";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MemberShip";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private TextBox txtPrice;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private Button Back;
        private Button Add_MemberShip;
        private Button Update_MemberShip;
        private Button Delete_MemberShip;
        private Button Search;
    }
}