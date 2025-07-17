namespace Condominium_System.Presentation.Views
{
    partial class UpsertFurnitureScreen
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
            label3 = new Label();
            panel5 = new Panel();
            FurnitureCBTypes = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            FurnitureTBDetail = new TextBox();
            label6 = new Label();
            panel6 = new Panel();
            FurnitureTBName = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(38, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 125;
            label3.Text = "Tipo";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(FurnitureCBTypes);
            panel5.Location = new Point(38, 42);
            panel5.Name = "panel5";
            panel5.Size = new Size(391, 30);
            panel5.TabIndex = 126;
            // 
            // FurnitureCBTypes
            // 
            FurnitureCBTypes.FormattingEnabled = true;
            FurnitureCBTypes.Location = new Point(0, 3);
            FurnitureCBTypes.Name = "FurnitureCBTypes";
            FurnitureCBTypes.Size = new Size(388, 23);
            FurnitureCBTypes.TabIndex = 0;
            FurnitureCBTypes.Text = "Seleccione";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(38, 168);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 123;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(FurnitureTBDetail);
            panel1.Location = new Point(38, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(396, 68);
            panel1.TabIndex = 124;
            // 
            // FurnitureTBDetail
            // 
            FurnitureTBDetail.BorderStyle = BorderStyle.None;
            FurnitureTBDetail.Location = new Point(4, 4);
            FurnitureTBDetail.Multiline = true;
            FurnitureTBDetail.Name = "FurnitureTBDetail";
            FurnitureTBDetail.Size = new Size(389, 57);
            FurnitureTBDetail.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(38, 94);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 121;
            label6.Text = "Nombre";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(FurnitureTBName);
            panel6.Location = new Point(38, 127);
            panel6.Name = "panel6";
            panel6.Size = new Size(394, 27);
            panel6.TabIndex = 122;
            // 
            // FurnitureTBName
            // 
            FurnitureTBName.BorderStyle = BorderStyle.None;
            FurnitureTBName.Location = new Point(3, 4);
            FurnitureTBName.Name = "FurnitureTBName";
            FurnitureTBName.Size = new Size(388, 16);
            FurnitureTBName.TabIndex = 3;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(150, 347);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 127;
            UpsertPNLBTN.Click += UpsertLBLBTN_Click;
            // 
            // UpsertLBLBTN
            // 
            UpsertLBLBTN.AutoSize = true;
            UpsertLBLBTN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpsertLBLBTN.ForeColor = Color.White;
            UpsertLBLBTN.Location = new Point(39, 12);
            UpsertLBLBTN.Name = "UpsertLBLBTN";
            UpsertLBLBTN.Size = new Size(67, 21);
            UpsertLBLBTN.TabIndex = 1;
            UpsertLBLBTN.Text = "Guardar";
            UpsertLBLBTN.Click += UpsertLBLBTN_Click;
            // 
            // UpsertPCTBXBTN
            // 
            UpsertPCTBXBTN.Image = Properties.Resources.save_white;
            UpsertPCTBXBTN.Location = new Point(3, 12);
            UpsertPCTBXBTN.Name = "UpsertPCTBXBTN";
            UpsertPCTBXBTN.Size = new Size(30, 19);
            UpsertPCTBXBTN.SizeMode = PictureBoxSizeMode.Zoom;
            UpsertPCTBXBTN.TabIndex = 0;
            UpsertPCTBXBTN.TabStop = false;
            UpsertPCTBXBTN.Click += UpsertLBLBTN_Click;
            // 
            // UpsertFurnitureScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 447);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label3);
            Controls.Add(panel5);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(panel6);
            Name = "UpsertFurnitureScreen";
            Text = "UpsertFurnitureScreen";
            Load += UpsertFurnitureScreen_Load;
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Panel panel5;
        private ComboBox FurnitureCBTypes;
        private Label label2;
        private Panel panel1;
        private TextBox FurnitureTBDetail;
        private Label label6;
        private Panel panel6;
        private TextBox FurnitureTBName;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
    }
}