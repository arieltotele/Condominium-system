namespace Condominium_System.Presentation.Views
{
    partial class UsersScreen
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
            LoginPNLUsername = new Panel();
            UserTxtBxPId = new TextBox();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            UserDTGData = new DataGridView();
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            LoginPNLUsername.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserDTGData).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(UserTxtBxPId);
            LoginPNLUsername.Location = new Point(12, 87);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(235, 24);
            LoginPNLUsername.TabIndex = 38;
            toolTip1.SetToolTip(LoginPNLUsername, "Buscar usuarios basado en criterios.");
            // 
            // UserTxtBxPId
            // 
            UserTxtBxPId.BorderStyle = BorderStyle.None;
            UserTxtBxPId.Location = new Point(4, 3);
            UserTxtBxPId.Name = "UserTxtBxPId";
            UserTxtBxPId.Size = new Size(228, 16);
            UserTxtBxPId.TabIndex = 2;
            toolTip1.SetToolTip(UserTxtBxPId, "Buscar usuarios basado en criterios.");
            UserTxtBxPId.TextChanged += UserTxtBxPId_TextChanged;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(856, 70);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 40;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear un nuevo usuario.");
            CondominiumPNLBTNCreate.Click += UserBTNCreate_Click;
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
            toolTip1.SetToolTip(label8, "Crear un nuevo usuario.");
            label8.Click += UserBTNCreate_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Crear un nuevo usuario.");
            pictureBox3.Click += UserBTNCreate_Click;
            // 
            // UserDTGData
            // 
            UserDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserDTGData.Dock = DockStyle.Bottom;
            UserDTGData.Location = new Point(0, 148);
            UserDTGData.Name = "UserDTGData";
            UserDTGData.Size = new Size(1017, 443);
            UserDTGData.TabIndex = 39;
            toolTip1.SetToolTip(UserDTGData, "Usuarios almacenados en la Base de Datos.");
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
            // panel2
            // 
            panel2.BackColor = Color.DarkGreen;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(672, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 41);
            panel2.TabIndex = 57;
            toolTip1.SetToolTip(panel2, "Generar reporte de usuarios.");
            panel2.Click += GenerateUserReportFromFilteredData_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(39, 12);
            label2.Name = "label2";
            label2.Size = new Size(125, 21);
            label2.TabIndex = 1;
            label2.Text = "Generar Reporte";
            toolTip1.SetToolTip(label2, "Generar reporte de usuarios.");
            label2.Click += GenerateUserReportFromFilteredData_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.export_white;
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Generar reporte de usuarios.");
            pictureBox1.Click += GenerateUserReportFromFilteredData_Click;
            // 
            // UsersScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(LoginPNLUsername);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(UserDTGData);
            Name = "UsersScreen";
            Text = "UsersScreen";
            toolTip1.SetToolTip(this, "Buscar usuarios basado en criterios.");
            Load += UsersScreen_Load;
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserDTGData).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel LoginPNLUsername;
        private TextBox UserTxtBxPId;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private ToolTip toolTip1;
        private PictureBox pictureBox3;
        private DataGridView UserDTGData;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
    }
}