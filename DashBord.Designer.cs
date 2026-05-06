namespace Gym_Management
{
    partial class DashBord
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBord));
            Member_Mangment = new Button();
            button2 = new Button();
            button3 = new Button();
            Equpment_inventory = new Button();
            Branch_Manger_info = new Button();
            SuspendLayout();
            // 
            // Member_Mangment
            // 
            Member_Mangment.Anchor = AnchorStyles.None;
            Member_Mangment.BackgroundImageLayout = ImageLayout.Zoom;
            Member_Mangment.ImageAlign = ContentAlignment.MiddleRight;
            Member_Mangment.Location = new Point(124, 106);
            Member_Mangment.Name = "Member_Mangment";
            Member_Mangment.Size = new Size(302, 50);
            Member_Mangment.TabIndex = 0;
            Member_Mangment.Text = "Member Management ";
            Member_Mangment.UseVisualStyleBackColor = true;
            Member_Mangment.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(124, 160);
            button2.Name = "button2";
            button2.Size = new Size(302, 52);
            button2.TabIndex = 1;
            button2.Text = "Trainer Management";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(124, 220);
            button3.Name = "button3";
            button3.Size = new Size(302, 49);
            button3.TabIndex = 2;
            button3.Text = "Class Schedule Management";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Equpment_inventory
            // 
            Equpment_inventory.Anchor = AnchorStyles.None;
            Equpment_inventory.Location = new Point(124, 275);
            Equpment_inventory.Name = "Equpment_inventory";
            Equpment_inventory.Size = new Size(302, 55);
            Equpment_inventory.TabIndex = 3;
            Equpment_inventory.Text = "Membership Management";
            Equpment_inventory.UseVisualStyleBackColor = true;
            Equpment_inventory.Click += button4_Click;
            // 
            // Branch_Manger_info
            // 
            Branch_Manger_info.Anchor = AnchorStyles.None;
            Branch_Manger_info.Location = new Point(124, 336);
            Branch_Manger_info.Name = "Branch_Manger_info";
            Branch_Manger_info.Size = new Size(302, 53);
            Branch_Manger_info.TabIndex = 4;
            Branch_Manger_info.Text = "Branch Management";
            Branch_Manger_info.UseVisualStyleBackColor = true;
            Branch_Manger_info.Click += button5_Click;
            // 
            // DashBord
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(535, 451);
            Controls.Add(button3);
            Controls.Add(Member_Mangment);
            Controls.Add(button2);
            Controls.Add(Equpment_inventory);
            Controls.Add(Branch_Manger_info);
            DoubleBuffered = true;
            Name = "DashBord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBored";
            Load += Member_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Member_Mangment;
        private Button button2;
        private Button button3;
        private Button Equpment_inventory;
        private Button Branch_Manger_info;
    }
}
