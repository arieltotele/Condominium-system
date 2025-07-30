namespace Condominium_System.Presentation.Views
{
    partial class UpsertServiceScreen
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
            label5 = new Label();
            panel3 = new Panel();
            ServiceTBCost = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            ServiceTBName = new TextBox();
            label3 = new Label();
            panel5 = new Panel();
            ServiceCBTypes = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            ServiceTBDetail = new TextBox();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            UpsertPNLBTN = new Panel();
            toolTip1 = new ToolTip(components);
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            UpsertPNLBTN.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(41, 163);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 142;
            label5.Text = "Costo";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(ServiceTBCost);
            panel3.Location = new Point(41, 196);
            panel3.Name = "panel3";
            panel3.Size = new Size(329, 24);
            panel3.TabIndex = 143;
            // 
            // ServiceTBCost
            // 
            ServiceTBCost.BorderStyle = BorderStyle.None;
            ServiceTBCost.Location = new Point(3, 5);
            ServiceTBCost.Name = "ServiceTBCost";
            ServiceTBCost.Size = new Size(322, 16);
            ServiceTBCost.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(41, 87);
            label4.Name = "label4";
            label4.Size = new Size(68, 21);
            label4.TabIndex = 140;
            label4.Text = "Nombre";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(ServiceTBName);
            panel2.Location = new Point(41, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 24);
            panel2.TabIndex = 141;
            // 
            // ServiceTBName
            // 
            ServiceTBName.BorderStyle = BorderStyle.None;
            ServiceTBName.Location = new Point(3, 3);
            ServiceTBName.Name = "ServiceTBName";
            ServiceTBName.Size = new Size(323, 16);
            ServiceTBName.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(41, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 21);
            label3.TabIndex = 138;
            label3.Text = "Tipo";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(ServiceCBTypes);
            panel5.Location = new Point(41, 42);
            panel5.Name = "panel5";
            panel5.Size = new Size(332, 30);
            panel5.TabIndex = 139;
            // 
            // ServiceCBTypes
            // 
            ServiceCBTypes.FormattingEnabled = true;
            ServiceCBTypes.Location = new Point(3, 4);
            ServiceCBTypes.Name = "ServiceCBTypes";
            ServiceCBTypes.Size = new Size(326, 23);
            ServiceCBTypes.TabIndex = 0;
            ServiceCBTypes.Text = "Seleccione";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(41, 252);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 144;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(ServiceTBDetail);
            panel1.Location = new Point(41, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 68);
            panel1.TabIndex = 145;
            // 
            // ServiceTBDetail
            // 
            ServiceTBDetail.BorderStyle = BorderStyle.None;
            ServiceTBDetail.Location = new Point(4, 4);
            ServiceTBDetail.Multiline = true;
            ServiceTBDetail.Name = "ServiceTBDetail";
            ServiceTBDetail.Size = new Size(322, 57);
            ServiceTBDetail.TabIndex = 2;
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
            toolTip1.SetToolTip(UpsertLBLBTN, "Guardar/Actualizar servicio.");
            UpsertLBLBTN.Click += UpsertPNLBTN_Click;
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
            toolTip1.SetToolTip(UpsertPCTBXBTN, "Guardar/Actualizar servicio.");
            UpsertPCTBXBTN.Click += UpsertPNLBTN_Click;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(133, 426);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 146;
            toolTip1.SetToolTip(UpsertPNLBTN, "Guardar/Actualizar servicio.");
            UpsertPNLBTN.Click += UpsertPNLBTN_Click;
            // 
            // UpsertServiceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 506);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel5);
            Name = "UpsertServiceScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpsertServiceScreen";
            Load += UpsertServiceScreen_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Panel panel3;
        private TextBox ServiceTBCost;
        private Label label4;
        private Panel panel2;
        private TextBox ServiceTBName;
        private Label label3;
        private Panel panel5;
        private ComboBox ServiceCBTypes;
        private Label label2;
        private Panel panel1;
        private TextBox ServiceTBDetail;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
        private Panel UpsertPNLBTN;
        private ToolTip toolTip1;
    }
}