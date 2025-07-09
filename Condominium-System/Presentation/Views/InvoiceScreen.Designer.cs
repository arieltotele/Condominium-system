namespace Condominium_System.Presentation.Views
{
    partial class InvoiceScreen
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
            label3 = new Label();
            panel2 = new Panel();
            InvoiceTBTotal = new TextBox();
            InvoiceDTGData = new DataGridView();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            CondominiumPNLBTNSearch = new Panel();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            CondominiumPNLBTNUpdate = new Panel();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            CondominiumPNLBTNDelete = new Panel();
            label13 = new Label();
            pictureBox4 = new PictureBox();
            label2 = new Label();
            panel1 = new Panel();
            InvoiceTBDetail = new TextBox();
            label1 = new Label();
            LoginPNLUsername = new Panel();
            InvoiceTBID = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            InvoiceCBTenants = new ComboBox();
            toolTip1 = new ToolTip(components);
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InvoiceDTGData).BeginInit();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            CondominiumPNLBTNSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            CondominiumPNLBTNUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CondominiumPNLBTNDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            LoginPNLUsername.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(826, 10);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 80;
            label3.Text = "Monto total";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(InvoiceTBTotal);
            panel2.Location = new Point(826, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(143, 24);
            panel2.TabIndex = 81;
            // 
            // InvoiceTBTotal
            // 
            InvoiceTBTotal.BorderStyle = BorderStyle.None;
            InvoiceTBTotal.Location = new Point(3, 3);
            InvoiceTBTotal.Name = "InvoiceTBTotal";
            InvoiceTBTotal.Size = new Size(137, 16);
            InvoiceTBTotal.TabIndex = 2;
            // 
            // InvoiceDTGData
            // 
            InvoiceDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InvoiceDTGData.Location = new Point(51, 271);
            InvoiceDTGData.Name = "InvoiceDTGData";
            InvoiceDTGData.Size = new Size(945, 309);
            InvoiceDTGData.TabIndex = 79;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(217, 186);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 78;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear factura.");
            CondominiumPNLBTNCreate.Click += InvoicePNLBTNCreate_Click;
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
            toolTip1.SetToolTip(label8, "Crear factura.");
            label8.Click += InvoicePNLBTNCreate_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Crear factura.");
            pictureBox3.Click += InvoicePNLBTNCreate_Click;
            // 
            // CondominiumPNLBTNSearch
            // 
            CondominiumPNLBTNSearch.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNSearch.Controls.Add(label9);
            CondominiumPNLBTNSearch.Controls.Add(pictureBox2);
            CondominiumPNLBTNSearch.Location = new Point(374, 186);
            CondominiumPNLBTNSearch.Name = "CondominiumPNLBTNSearch";
            CondominiumPNLBTNSearch.Size = new Size(109, 41);
            CondominiumPNLBTNSearch.TabIndex = 77;
            toolTip1.SetToolTip(CondominiumPNLBTNSearch, "Buscar factura.");
            CondominiumPNLBTNSearch.Click += InvoicePNLBTNSearch_Click;
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
            toolTip1.SetToolTip(label9, "Buscar factura.");
            label9.Click += InvoicePNLBTNSearch_Click;
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
            toolTip1.SetToolTip(pictureBox2, "Buscar factura.");
            pictureBox2.Click += InvoicePNLBTNSearch_Click;
            // 
            // CondominiumPNLBTNUpdate
            // 
            CondominiumPNLBTNUpdate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNUpdate.Controls.Add(label10);
            CondominiumPNLBTNUpdate.Controls.Add(pictureBox1);
            CondominiumPNLBTNUpdate.Location = new Point(544, 186);
            CondominiumPNLBTNUpdate.Name = "CondominiumPNLBTNUpdate";
            CondominiumPNLBTNUpdate.Size = new Size(119, 41);
            CondominiumPNLBTNUpdate.TabIndex = 76;
            toolTip1.SetToolTip(CondominiumPNLBTNUpdate, "Actualizar factura.");
            CondominiumPNLBTNUpdate.Click += InvoicePNLBTNUpdate_Click;
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
            toolTip1.SetToolTip(label10, "Actualizar factura.");
            label10.Click += InvoicePNLBTNUpdate_Click;
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
            toolTip1.SetToolTip(pictureBox1, "Actualizar factura.");
            pictureBox1.Click += InvoicePNLBTNUpdate_Click;
            // 
            // CondominiumPNLBTNDelete
            // 
            CondominiumPNLBTNDelete.BackColor = Color.FromArgb(199, 0, 0);
            CondominiumPNLBTNDelete.Controls.Add(label13);
            CondominiumPNLBTNDelete.Controls.Add(pictureBox4);
            CondominiumPNLBTNDelete.Location = new Point(714, 186);
            CondominiumPNLBTNDelete.Name = "CondominiumPNLBTNDelete";
            CondominiumPNLBTNDelete.Size = new Size(109, 41);
            CondominiumPNLBTNDelete.TabIndex = 75;
            toolTip1.SetToolTip(CondominiumPNLBTNDelete, "Borrar factura.");
            CondominiumPNLBTNDelete.Click += InvoicePNLBTNDelete_Click;
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
            toolTip1.SetToolTip(label13, "Borrar factura.");
            label13.Click += InvoicePNLBTNDelete_Click;
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
            toolTip1.SetToolTip(pictureBox4, "Borrar factura.");
            pictureBox4.Click += InvoicePNLBTNDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(503, 10);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 73;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(InvoiceTBDetail);
            panel1.Location = new Point(503, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 68);
            panel1.TabIndex = 74;
            // 
            // InvoiceTBDetail
            // 
            InvoiceTBDetail.BorderStyle = BorderStyle.None;
            InvoiceTBDetail.Location = new Point(4, 4);
            InvoiceTBDetail.Multiline = true;
            InvoiceTBDetail.Name = "InvoiceTBDetail";
            InvoiceTBDetail.Size = new Size(232, 57);
            InvoiceTBDetail.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 69;
            label1.Text = "ID";
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(InvoiceTBID);
            LoginPNLUsername.Location = new Point(21, 43);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(119, 24);
            LoginPNLUsername.TabIndex = 70;
            // 
            // InvoiceTBID
            // 
            InvoiceTBID.BorderStyle = BorderStyle.None;
            InvoiceTBID.Location = new Point(4, 4);
            InvoiceTBID.Name = "InvoiceTBID";
            InvoiceTBID.Size = new Size(112, 16);
            InvoiceTBID.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(191, 10);
            label6.Name = "label6";
            label6.Size = new Size(192, 21);
            label6.TabIndex = 99;
            label6.Text = "Identificación del inquilino";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(InvoiceCBTenants);
            panel6.Location = new Point(191, 43);
            panel6.Name = "panel6";
            panel6.Size = new Size(230, 33);
            panel6.TabIndex = 100;
            // 
            // InvoiceCBTenants
            // 
            InvoiceCBTenants.DropDownStyle = ComboBoxStyle.DropDownList;
            InvoiceCBTenants.FormattingEnabled = true;
            InvoiceCBTenants.Location = new Point(3, 6);
            InvoiceCBTenants.Name = "InvoiceCBTenants";
            InvoiceCBTenants.Size = new Size(224, 23);
            InvoiceCBTenants.TabIndex = 0;
            // 
            // InvoiceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(InvoiceDTGData);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(CondominiumPNLBTNSearch);
            Controls.Add(CondominiumPNLBTNUpdate);
            Controls.Add(CondominiumPNLBTNDelete);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(LoginPNLUsername);
            Name = "InvoiceScreen";
            Text = "InvoiceScreen";
            Load += InvoiceScreen_Load;
            Click += InvoicePNLBTNDelete_Click;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InvoiceDTGData).EndInit();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            CondominiumPNLBTNSearch.ResumeLayout(false);
            CondominiumPNLBTNSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            CondominiumPNLBTNUpdate.ResumeLayout(false);
            CondominiumPNLBTNUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            CondominiumPNLBTNDelete.ResumeLayout(false);
            CondominiumPNLBTNDelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Panel panel2;
        private TextBox InvoiceTBTotal;
        private DataGridView InvoiceDTGData;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private Panel CondominiumPNLBTNSearch;
        private Label label9;
        private PictureBox pictureBox2;
        private Panel CondominiumPNLBTNUpdate;
        private Label label10;
        private PictureBox pictureBox1;
        private Panel CondominiumPNLBTNDelete;
        private Label label13;
        private PictureBox pictureBox4;
        private Label label2;
        private Panel panel1;
        private TextBox InvoiceTBDetail;
        private Label label1;
        private Panel LoginPNLUsername;
        private TextBox InvoiceTBID;
        private Label label6;
        private Panel panel6;
        private ComboBox InvoiceCBTenants;
        private ToolTip toolTip1;
    }
}