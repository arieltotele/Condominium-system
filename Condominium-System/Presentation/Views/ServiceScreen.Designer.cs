namespace Condominium_System.Presentation.Views
{
    partial class ServiceScreen
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
            ServiceCBTypes = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            ServiceTBDetail = new TextBox();
            panel5 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            label10 = new Label();
            CondominiumPNLBTNUpdate = new Panel();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            CondominiumPNLBTNSearch = new Panel();
            ServiceTBID = new TextBox();
            ServiceDTGData = new DataGridView();
            LoginPNLUsername = new Panel();
            CondominiumPNLBTNDelete = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            ServiceTBName = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            ServiceTBCost = new TextBox();
            toolTip1 = new ToolTip(components);
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            CondominiumPNLBTNUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            CondominiumPNLBTNSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ServiceDTGData).BeginInit();
            LoginPNLUsername.SuspendLayout();
            CondominiumPNLBTNDelete.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // ServiceCBTypes
            // 
            ServiceCBTypes.FormattingEnabled = true;
            ServiceCBTypes.Location = new Point(3, 4);
            ServiceCBTypes.Name = "ServiceCBTypes";
            ServiceCBTypes.Size = new Size(181, 23);
            ServiceCBTypes.TabIndex = 0;
            ServiceCBTypes.Text = "Seleccione";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(217, 10);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 132;
            label3.Text = "Tipo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 121;
            label1.Text = "ID";
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(207, 230);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 130;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear servicio.");
            CondominiumPNLBTNCreate.Click += ServicePNLBTNCreate_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(39, 12);
            label8.Name = "label8";
            label8.Size = new Size(48, 21);
            label8.TabIndex = 1;
            label8.Text = "Crear";
            toolTip1.SetToolTip(label8, "Crear servicio.");
            label8.Click += ServicePNLBTNCreate_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Crear servicio.");
            pictureBox3.Click += ServicePNLBTNCreate_Click;
            // 
            // ServiceTBDetail
            // 
            ServiceTBDetail.BorderStyle = BorderStyle.None;
            ServiceTBDetail.Location = new Point(4, 4);
            ServiceTBDetail.Multiline = true;
            ServiceTBDetail.Name = "ServiceTBDetail";
            ServiceTBDetail.Size = new Size(232, 57);
            ServiceTBDetail.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(ServiceCBTypes);
            panel5.Location = new Point(217, 43);
            panel5.Name = "panel5";
            panel5.Size = new Size(187, 30);
            panel5.TabIndex = 133;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(21, 92);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 125;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(ServiceTBDetail);
            panel1.Location = new Point(21, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 68);
            panel1.TabIndex = 126;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(39, 12);
            label13.Name = "label13";
            label13.Size = new Size(54, 21);
            label13.TabIndex = 1;
            label13.Text = "Borrar";
            toolTip1.SetToolTip(label13, "Borrar servicio.");
            label13.Click += ServicePNLBTNDelete_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.update_white;
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Actualizar servicio.");
            pictureBox1.Click += ServicePNLBTNUpdate_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.trash_white;
            pictureBox4.Location = new Point(3, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 19);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            toolTip1.SetToolTip(pictureBox4, "Borrar servicio.");
            pictureBox4.Click += ServicePNLBTNDelete_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(39, 12);
            label10.Name = "label10";
            label10.Size = new Size(78, 21);
            label10.TabIndex = 1;
            label10.Text = "Actualizar";
            toolTip1.SetToolTip(label10, "Actualizar servicio.");
            label10.Click += ServicePNLBTNUpdate_Click;
            // 
            // CondominiumPNLBTNUpdate
            // 
            CondominiumPNLBTNUpdate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNUpdate.Controls.Add(label10);
            CondominiumPNLBTNUpdate.Controls.Add(pictureBox1);
            CondominiumPNLBTNUpdate.Location = new Point(534, 230);
            CondominiumPNLBTNUpdate.Name = "CondominiumPNLBTNUpdate";
            CondominiumPNLBTNUpdate.Size = new Size(119, 41);
            CondominiumPNLBTNUpdate.TabIndex = 128;
            toolTip1.SetToolTip(CondominiumPNLBTNUpdate, "Actualizar servicio.");
            CondominiumPNLBTNUpdate.Click += ServicePNLBTNUpdate_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(39, 12);
            label9.Name = "label9";
            label9.Size = new Size(56, 21);
            label9.TabIndex = 1;
            label9.Text = "Buscar";
            toolTip1.SetToolTip(label9, "Buscar servicio.");
            label9.Click += ServicePNLBTNSearch_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.search_white;
            pictureBox2.Location = new Point(3, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 19);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Buscar servicio.");
            pictureBox2.Click += ServicePNLBTNSearch_Click;
            // 
            // CondominiumPNLBTNSearch
            // 
            CondominiumPNLBTNSearch.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNSearch.Controls.Add(label9);
            CondominiumPNLBTNSearch.Controls.Add(pictureBox2);
            CondominiumPNLBTNSearch.Location = new Point(364, 230);
            CondominiumPNLBTNSearch.Name = "CondominiumPNLBTNSearch";
            CondominiumPNLBTNSearch.Size = new Size(109, 41);
            CondominiumPNLBTNSearch.TabIndex = 129;
            toolTip1.SetToolTip(CondominiumPNLBTNSearch, "Buscar servicio.");
            CondominiumPNLBTNSearch.Click += ServicePNLBTNSearch_Click;
            // 
            // ServiceTBID
            // 
            ServiceTBID.BorderStyle = BorderStyle.None;
            ServiceTBID.Location = new Point(4, 4);
            ServiceTBID.Name = "ServiceTBID";
            ServiceTBID.Size = new Size(112, 16);
            ServiceTBID.TabIndex = 2;
            // 
            // ServiceDTGData
            // 
            ServiceDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ServiceDTGData.Location = new Point(51, 292);
            ServiceDTGData.Name = "ServiceDTGData";
            ServiceDTGData.Size = new Size(945, 288);
            ServiceDTGData.TabIndex = 131;
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(ServiceTBID);
            LoginPNLUsername.Location = new Point(21, 43);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(119, 24);
            LoginPNLUsername.TabIndex = 122;
            // 
            // CondominiumPNLBTNDelete
            // 
            CondominiumPNLBTNDelete.BackColor = Color.FromArgb(199, 0, 0);
            CondominiumPNLBTNDelete.Controls.Add(label13);
            CondominiumPNLBTNDelete.Controls.Add(pictureBox4);
            CondominiumPNLBTNDelete.Location = new Point(704, 230);
            CondominiumPNLBTNDelete.Name = "CondominiumPNLBTNDelete";
            CondominiumPNLBTNDelete.Size = new Size(109, 41);
            CondominiumPNLBTNDelete.TabIndex = 127;
            toolTip1.SetToolTip(CondominiumPNLBTNDelete, "Borrar servicio.");
            CondominiumPNLBTNDelete.Click += ServicePNLBTNDelete_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(481, 10);
            label4.Name = "label4";
            label4.Size = new Size(68, 21);
            label4.TabIndex = 134;
            label4.Text = "Nombre";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(ServiceTBName);
            panel2.Location = new Point(481, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(215, 24);
            panel2.TabIndex = 135;
            // 
            // ServiceTBName
            // 
            ServiceTBName.BorderStyle = BorderStyle.None;
            ServiceTBName.Location = new Point(4, 4);
            ServiceTBName.Name = "ServiceTBName";
            ServiceTBName.Size = new Size(208, 16);
            ServiceTBName.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(763, 10);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 136;
            label5.Text = "Costo";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(ServiceTBCost);
            panel3.Location = new Point(763, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(149, 24);
            panel3.TabIndex = 137;
            // 
            // ServiceTBCost
            // 
            ServiceTBCost.BorderStyle = BorderStyle.None;
            ServiceTBCost.Location = new Point(4, 4);
            ServiceTBCost.Name = "ServiceTBCost";
            ServiceTBCost.Size = new Size(142, 16);
            ServiceTBCost.TabIndex = 2;
            // 
            // ServiceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(label5);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(panel5);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(CondominiumPNLBTNUpdate);
            Controls.Add(CondominiumPNLBTNSearch);
            Controls.Add(ServiceDTGData);
            Controls.Add(LoginPNLUsername);
            Controls.Add(CondominiumPNLBTNDelete);
            Name = "ServiceScreen";
            Text = "ServiceScreen";
            Load += ServiceScreen_Load;
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            CondominiumPNLBTNUpdate.ResumeLayout(false);
            CondominiumPNLBTNUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            CondominiumPNLBTNSearch.ResumeLayout(false);
            CondominiumPNLBTNSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ServiceDTGData).EndInit();
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            CondominiumPNLBTNDelete.ResumeLayout(false);
            CondominiumPNLBTNDelete.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ServiceCBTypes;
        private Label label3;
        private Label label1;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private TextBox ServiceTBDetail;
        private Panel panel5;
        private Label label2;
        private Panel panel1;
        private Label label13;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private Label label10;
        private Panel CondominiumPNLBTNUpdate;
        private Label label9;
        private PictureBox pictureBox2;
        private Panel CondominiumPNLBTNSearch;
        private TextBox ServiceTBID;
        private DataGridView ServiceDTGData;
        private Panel LoginPNLUsername;
        private Panel CondominiumPNLBTNDelete;
        private Label label4;
        private Panel panel2;
        private TextBox ServiceTBName;
        private Label label5;
        private Panel panel3;
        private TextBox ServiceTBCost;
        private ToolTip toolTip1;
    }
}