namespace Condominium_System.Presentation.Views
{
    partial class AddFurnitureScreen
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
            components = new System.ComponentModel.Container();
            HomeScreenLBLTitle = new Label();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SignUpPNLBTNClean = new Panel();
            label12 = new Label();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            AddFurnitrureFlowLayoutLivingRoom = new FlowLayoutPanel();
            AddFurnitrureFlowLayoutDinningRoom = new FlowLayoutPanel();
            AddFurnitrureFlowLayoutBedroom = new FlowLayoutPanel();
            AddFurnitrureFlowLayoutKitchen = new FlowLayoutPanel();
            AddFurnitrureFlowLayoutOutside = new FlowLayoutPanel();
            toolTip1 = new ToolTip(components);
            panel3.SuspendLayout();
            SignUpPNLBTNClean.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // HomeScreenLBLTitle
            // 
            HomeScreenLBLTitle.AutoSize = true;
            HomeScreenLBLTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HomeScreenLBLTitle.Location = new Point(21, 15);
            HomeScreenLBLTitle.Name = "HomeScreenLBLTitle";
            HomeScreenLBLTitle.Size = new Size(366, 32);
            HomeScreenLBLTitle.TabIndex = 0;
            HomeScreenLBLTitle.Text = "Añadir inmuebles a la vivienda";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(217, 217, 217);
            panel3.Controls.Add(HomeScreenLBLTitle);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(1329, 59);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 4;
            label1.Text = "Sala de estar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(294, 79);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 9;
            label2.Text = "Comedor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(590, 79);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 14;
            label3.Text = "Dormitorio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1108, 79);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 24;
            label4.Text = "Exterior";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(865, 79);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 19;
            label5.Text = "Cocina";
            // 
            // SignUpPNLBTNClean
            // 
            SignUpPNLBTNClean.BackColor = Color.MidnightBlue;
            SignUpPNLBTNClean.Controls.Add(label12);
            SignUpPNLBTNClean.Controls.Add(pictureBox3);
            SignUpPNLBTNClean.Location = new Point(311, 438);
            SignUpPNLBTNClean.Name = "SignUpPNLBTNClean";
            SignUpPNLBTNClean.Size = new Size(109, 41);
            SignUpPNLBTNClean.TabIndex = 31;
            toolTip1.SetToolTip(SignUpPNLBTNClean, "Limpiar formulario.");
            SignUpPNLBTNClean.Click += AddFurniturePNLBTNClean_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(39, 12);
            label12.Name = "label12";
            label12.Size = new Size(63, 21);
            label12.TabIndex = 1;
            label12.Text = "Limpiar";
            toolTip1.SetToolTip(label12, "Limpiar formulario.");
            label12.Click += AddFurniturePNLBTNClean_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.clean_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "Limpiar formulario.");
            pictureBox3.Click += AddFurniturePNLBTNClean_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(862, 438);
            panel1.Name = "panel1";
            panel1.Size = new Size(109, 41);
            panel1.TabIndex = 32;
            toolTip1.SetToolTip(panel1, "Ir a la siguiente pantalla.");
            panel1.Click += AddFurniturePNLBTNNext_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 12);
            label6.Name = "label6";
            label6.Size = new Size(75, 21);
            label6.TabIndex = 1;
            label6.Text = "Siguiente";
            toolTip1.SetToolTip(label6, "Ir a la siguiente pantalla.");
            label6.Click += AddFurniturePNLBTNNext_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.next_white;
            pictureBox1.Location = new Point(73, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Ir a la siguiente pantalla.");
            pictureBox1.Click += AddFurniturePNLBTNNext_Click;
            // 
            // AddFurnitrureFlowLayoutLivingRoom
            // 
            AddFurnitrureFlowLayoutLivingRoom.Location = new Point(12, 107);
            AddFurnitrureFlowLayoutLivingRoom.Name = "AddFurnitrureFlowLayoutLivingRoom";
            AddFurnitrureFlowLayoutLivingRoom.Size = new Size(200, 286);
            AddFurnitrureFlowLayoutLivingRoom.TabIndex = 33;
            // 
            // AddFurnitrureFlowLayoutDinningRoom
            // 
            AddFurnitrureFlowLayoutDinningRoom.Location = new Point(294, 107);
            AddFurnitrureFlowLayoutDinningRoom.Name = "AddFurnitrureFlowLayoutDinningRoom";
            AddFurnitrureFlowLayoutDinningRoom.Size = new Size(200, 286);
            AddFurnitrureFlowLayoutDinningRoom.TabIndex = 34;
            // 
            // AddFurnitrureFlowLayoutBedroom
            // 
            AddFurnitrureFlowLayoutBedroom.Location = new Point(590, 107);
            AddFurnitrureFlowLayoutBedroom.Name = "AddFurnitrureFlowLayoutBedroom";
            AddFurnitrureFlowLayoutBedroom.Size = new Size(200, 286);
            AddFurnitrureFlowLayoutBedroom.TabIndex = 35;
            // 
            // AddFurnitrureFlowLayoutKitchen
            // 
            AddFurnitrureFlowLayoutKitchen.Location = new Point(862, 107);
            AddFurnitrureFlowLayoutKitchen.Name = "AddFurnitrureFlowLayoutKitchen";
            AddFurnitrureFlowLayoutKitchen.Size = new Size(200, 286);
            AddFurnitrureFlowLayoutKitchen.TabIndex = 34;
            // 
            // AddFurnitrureFlowLayoutOutside
            // 
            AddFurnitrureFlowLayoutOutside.Location = new Point(1108, 107);
            AddFurnitrureFlowLayoutOutside.Name = "AddFurnitrureFlowLayoutOutside";
            AddFurnitrureFlowLayoutOutside.Size = new Size(200, 286);
            AddFurnitrureFlowLayoutOutside.TabIndex = 34;
            // 
            // AddFurnitureScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 504);
            Controls.Add(panel1);
            Controls.Add(SignUpPNLBTNClean);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(AddFurnitrureFlowLayoutLivingRoom);
            Controls.Add(AddFurnitrureFlowLayoutDinningRoom);
            Controls.Add(AddFurnitrureFlowLayoutBedroom);
            Controls.Add(AddFurnitrureFlowLayoutKitchen);
            Controls.Add(AddFurnitrureFlowLayoutOutside);
            Name = "AddFurnitureScreen";
            Text = "AddFurnitureScreen";
            toolTip1.SetToolTip(this, "Ir a la siguiente pantalla.");
            Load += AddFurnitureScreen_Load;
            Click += AddFurniturePNLBTNNext_Click;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            SignUpPNLBTNClean.ResumeLayout(false);
            SignUpPNLBTNClean.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HomeScreenLBLTitle;
        private Panel panel3;
        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel SignUpPNLBTNClean;
        private Label label12;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Label label6;
        private PictureBox pictureBox1;
        private FlowLayoutPanel AddFurnitrureFlowLayoutLivingRoom;
        private FlowLayoutPanel AddFurnitrureFlowLayoutDinningRoom;
        private FlowLayoutPanel AddFurnitrureFlowLayoutBedroom;
        private FlowLayoutPanel AddFurnitrureFlowLayoutKitchen;
        private FlowLayoutPanel AddFurnitrureFlowLayoutOutside;
        private ToolTip toolTip1;
    }
}