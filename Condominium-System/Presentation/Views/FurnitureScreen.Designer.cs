namespace Condominium_System.Presentation.Views
{
    partial class FurnitureScreen
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
            label1 = new Label();
            LoginPNLUsername = new Panel();
            FurnitureTBID = new TextBox();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            FurnitureDTGData = new DataGridView();
            toolTip1 = new ToolTip(components);
            panel1 = new Panel();
            pictureBox5 = new PictureBox();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            LoginPNLUsername.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FurnitureDTGData).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 37;
            label1.Text = "ID";
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(FurnitureTBID);
            LoginPNLUsername.Location = new Point(12, 81);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(235, 24);
            LoginPNLUsername.TabIndex = 38;
            // 
            // FurnitureTBID
            // 
            FurnitureTBID.BorderStyle = BorderStyle.None;
            FurnitureTBID.Location = new Point(4, 3);
            FurnitureTBID.Name = "FurnitureTBID";
            FurnitureTBID.Size = new Size(228, 16);
            FurnitureTBID.TabIndex = 2;
            FurnitureTBID.TextChanged += FurnitureTBID_TextChanged;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(856, 64);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 40;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear un nuevo mobiliario.");
            CondominiumPNLBTNCreate.Click += FurniturePNLBTNCreate_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(39, 12);
            label8.Name = "label8";
            label8.Size = new Size(56, 21);
            label8.TabIndex = 1;
            label8.Text = "Nuevo";
            toolTip1.SetToolTip(label8, "Crear un nuevo mobiliario.");
            label8.Click += FurniturePNLBTNCreate_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.create_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "Crear un nuevo mobiliario.");
            pictureBox3.Click += FurniturePNLBTNCreate_Click;
            // 
            // FurnitureDTGData
            // 
            FurnitureDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FurnitureDTGData.Dock = DockStyle.Bottom;
            FurnitureDTGData.Location = new Point(0, 148);
            FurnitureDTGData.Name = "FurnitureDTGData";
            FurnitureDTGData.Size = new Size(1017, 443);
            FurnitureDTGData.TabIndex = 39;
            toolTip1.SetToolTip(FurnitureDTGData, "Condominios almacenados en la Base de Datos.");
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox5);
            panel1.Location = new Point(244, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(26, 24);
            panel1.TabIndex = 41;
            toolTip1.SetToolTip(panel1, "Boton para buscar un condominio.");
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.search_white;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            toolTip1.SetToolTip(pictureBox5, "Boton para buscar mobiliario.");
            pictureBox5.Click += FurniturePNLBTNSearch_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 126);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1017, 22);
            statusStrip1.TabIndex = 42;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = false;
            statusLabel.ForeColor = Color.FromArgb(238, 210, 2);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1002, 17);
            statusLabel.Spring = true;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FurnitureScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(statusStrip1);
            Controls.Add(label1);
            Controls.Add(LoginPNLUsername);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(FurnitureDTGData);
            Controls.Add(panel1);
            Name = "FurnitureScreen";
            Text = "FurnitureScreen";
            Load += FurnitureScreen_Load;
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)FurnitureDTGData).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel LoginPNLUsername;
        private TextBox FurnitureTBID;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private ToolTip toolTip1;
        private PictureBox pictureBox3;
        private DataGridView FurnitureDTGData;
        private Panel panel1;
        private PictureBox pictureBox5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
    }
}