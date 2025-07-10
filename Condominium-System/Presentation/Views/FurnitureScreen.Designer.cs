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
            FurnitureDTGData = new DataGridView();
            LoginPNLUsername = new Panel();
            FurnitureTBID = new TextBox();
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
            FurnitureTBDetail = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            FurnitureTBName = new TextBox();
            label1 = new Label();
            CondominiumPNLBTNCreate = new Panel();
            label3 = new Label();
            panel5 = new Panel();
            FurnitureCBTypes = new ComboBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)FurnitureDTGData).BeginInit();
            LoginPNLUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            CondominiumPNLBTNSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            CondominiumPNLBTNUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CondominiumPNLBTNDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // FurnitureDTGData
            // 
            FurnitureDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FurnitureDTGData.Location = new Point(51, 249);
            FurnitureDTGData.Name = "FurnitureDTGData";
            FurnitureDTGData.Size = new Size(945, 331);
            FurnitureDTGData.TabIndex = 118;
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(FurnitureTBID);
            LoginPNLUsername.Location = new Point(21, 43);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(119, 24);
            LoginPNLUsername.TabIndex = 107;
            // 
            // FurnitureTBID
            // 
            FurnitureTBID.BorderStyle = BorderStyle.None;
            FurnitureTBID.Location = new Point(4, 4);
            FurnitureTBID.Name = "FurnitureTBID";
            FurnitureTBID.Size = new Size(112, 16);
            FurnitureTBID.TabIndex = 2;
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
            toolTip1.SetToolTip(label8, "Crear mobiliario.");
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
            toolTip1.SetToolTip(pictureBox3, "Crear mobiliario.");
            pictureBox3.Click += FurniturePNLBTNCreate_Click;
            // 
            // CondominiumPNLBTNSearch
            // 
            CondominiumPNLBTNSearch.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNSearch.Controls.Add(label9);
            CondominiumPNLBTNSearch.Controls.Add(pictureBox2);
            CondominiumPNLBTNSearch.Location = new Point(374, 167);
            CondominiumPNLBTNSearch.Name = "CondominiumPNLBTNSearch";
            CondominiumPNLBTNSearch.Size = new Size(109, 41);
            CondominiumPNLBTNSearch.TabIndex = 116;
            toolTip1.SetToolTip(CondominiumPNLBTNSearch, "Buscar mobiliario.");
            CondominiumPNLBTNSearch.Click += FurniturePNLBTNSearch_Click;
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
            toolTip1.SetToolTip(label9, "Buscar mobiliario.");
            label9.Click += FurniturePNLBTNSearch_Click;
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
            toolTip1.SetToolTip(pictureBox2, "Buscar mobiliario.");
            pictureBox2.Click += FurniturePNLBTNSearch_Click;
            // 
            // CondominiumPNLBTNUpdate
            // 
            CondominiumPNLBTNUpdate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNUpdate.Controls.Add(label10);
            CondominiumPNLBTNUpdate.Controls.Add(pictureBox1);
            CondominiumPNLBTNUpdate.Location = new Point(544, 167);
            CondominiumPNLBTNUpdate.Name = "CondominiumPNLBTNUpdate";
            CondominiumPNLBTNUpdate.Size = new Size(119, 41);
            CondominiumPNLBTNUpdate.TabIndex = 115;
            toolTip1.SetToolTip(CondominiumPNLBTNUpdate, "Actualizar mobiliario.");
            CondominiumPNLBTNUpdate.Click += FurniturePNLBTNUpdate_Click;
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
            toolTip1.SetToolTip(label10, "Actualizar mobiliario.");
            label10.Click += FurniturePNLBTNUpdate_Click;
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
            toolTip1.SetToolTip(pictureBox1, "Actualizar mobiliario.");
            pictureBox1.Click += FurniturePNLBTNUpdate_Click;
            // 
            // CondominiumPNLBTNDelete
            // 
            CondominiumPNLBTNDelete.BackColor = Color.FromArgb(199, 0, 0);
            CondominiumPNLBTNDelete.Controls.Add(label13);
            CondominiumPNLBTNDelete.Controls.Add(pictureBox4);
            CondominiumPNLBTNDelete.Location = new Point(714, 167);
            CondominiumPNLBTNDelete.Name = "CondominiumPNLBTNDelete";
            CondominiumPNLBTNDelete.Size = new Size(109, 41);
            CondominiumPNLBTNDelete.TabIndex = 114;
            toolTip1.SetToolTip(CondominiumPNLBTNDelete, "Borrar mobiliario.");
            CondominiumPNLBTNDelete.Click += FurniturePNLBTNDelete_Click;
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
            toolTip1.SetToolTip(label13, "Borrar mobiliario.");
            label13.Click += FurniturePNLBTNDelete_Click;
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
            toolTip1.SetToolTip(pictureBox4, "Borrar mobiliario.");
            pictureBox4.Click += FurniturePNLBTNDelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(757, 10);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 112;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(FurnitureTBDetail);
            panel1.Location = new Point(757, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 68);
            panel1.TabIndex = 113;
            // 
            // FurnitureTBDetail
            // 
            FurnitureTBDetail.BorderStyle = BorderStyle.None;
            FurnitureTBDetail.Location = new Point(4, 4);
            FurnitureTBDetail.Multiline = true;
            FurnitureTBDetail.Name = "FurnitureTBDetail";
            FurnitureTBDetail.Size = new Size(232, 57);
            FurnitureTBDetail.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(471, 10);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 110;
            label6.Text = "Nombre";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(FurnitureTBName);
            panel6.Location = new Point(471, 43);
            panel6.Name = "panel6";
            panel6.Size = new Size(230, 27);
            panel6.TabIndex = 111;
            // 
            // FurnitureTBName
            // 
            FurnitureTBName.BorderStyle = BorderStyle.None;
            FurnitureTBName.Location = new Point(3, 4);
            FurnitureTBName.Name = "FurnitureTBName";
            FurnitureTBName.Size = new Size(224, 16);
            FurnitureTBName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 106;
            label1.Text = "ID";
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(217, 167);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 117;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear mobiliario.");
            CondominiumPNLBTNCreate.Click += FurniturePNLBTNCreate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(217, 10);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 119;
            label3.Text = "Tipo";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(FurnitureCBTypes);
            panel5.Location = new Point(217, 43);
            panel5.Name = "panel5";
            panel5.Size = new Size(187, 30);
            panel5.TabIndex = 120;
            // 
            // FurnitureCBTypes
            // 
            FurnitureCBTypes.FormattingEnabled = true;
            FurnitureCBTypes.Location = new Point(3, 4);
            FurnitureCBTypes.Name = "FurnitureCBTypes";
            FurnitureCBTypes.Size = new Size(181, 23);
            FurnitureCBTypes.TabIndex = 0;
            FurnitureCBTypes.Text = "Seleccione";
            // 
            // FurnitureScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(label3);
            Controls.Add(panel5);
            Controls.Add(FurnitureDTGData);
            Controls.Add(LoginPNLUsername);
            Controls.Add(CondominiumPNLBTNSearch);
            Controls.Add(CondominiumPNLBTNUpdate);
            Controls.Add(CondominiumPNLBTNDelete);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label1);
            Controls.Add(CondominiumPNLBTNCreate);
            Name = "FurnitureScreen";
            Text = "FurnitureScreen";
            toolTip1.SetToolTip(this, "Borrar mobiliario.");
            Load += FurnitureScreen_Load;
            Click += FurniturePNLBTNDelete_Click;
            ((System.ComponentModel.ISupportInitialize)FurnitureDTGData).EndInit();
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
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
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView FurnitureDTGData;
        private Panel LoginPNLUsername;
        private TextBox FurnitureTBID;
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
        private TextBox FurnitureTBDetail;
        private Label label6;
        private Panel panel6;
        private Label label1;
        private Panel CondominiumPNLBTNCreate;
        private Label label3;
        private Panel panel5;
        private ComboBox FurnitureCBTypes;
        private TextBox FurnitureTBName;
        private ToolTip toolTip1;
    }
}