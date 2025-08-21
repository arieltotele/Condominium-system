namespace Condominium_System.Presentation.Views
{
    partial class UpsertTenantScreen
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
            label11 = new Label();
            panel8 = new Panel();
            TenantCBHouses = new ComboBox();
            label7 = new Label();
            panel7 = new Panel();
            TenantMskTPhoneNumber = new MaskedTextBox();
            label6 = new Label();
            panel6 = new Panel();
            TenantMskTDocumentation = new MaskedTextBox();
            label5 = new Label();
            panel5 = new Panel();
            TenantDTPBirthdate = new DateTimePicker();
            label3 = new Label();
            panel3 = new Panel();
            TenantCBSexs = new ComboBox();
            label4 = new Label();
            panel4 = new Panel();
            TenantTBLastname = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            TenantTBName = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            toolTip1 = new ToolTip(components);
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(79, 457);
            label11.Name = "label11";
            label11.Size = new Size(70, 21);
            label11.TabIndex = 76;
            label11.Text = "Vivienda";
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Window;
            panel8.Controls.Add(TenantCBHouses);
            panel8.Location = new Point(79, 475);
            panel8.Name = "panel8";
            panel8.Size = new Size(299, 31);
            panel8.TabIndex = 77;
            // 
            // TenantCBHouses
            // 
            TenantCBHouses.DropDownStyle = ComboBoxStyle.DropDownList;
            TenantCBHouses.FormattingEnabled = true;
            TenantCBHouses.Location = new Point(4, 4);
            TenantCBHouses.Name = "TenantCBHouses";
            TenantCBHouses.Size = new Size(292, 23);
            TenantCBHouses.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(79, 375);
            label7.Name = "label7";
            label7.Size = new Size(150, 21);
            label7.TabIndex = 74;
            label7.Text = "Número de teléfono";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.Controls.Add(TenantMskTPhoneNumber);
            panel7.Location = new Point(79, 408);
            panel7.Name = "panel7";
            panel7.Size = new Size(299, 33);
            panel7.TabIndex = 75;
            // 
            // TenantMskTPhoneNumber
            // 
            TenantMskTPhoneNumber.Location = new Point(4, 5);
            TenantMskTPhoneNumber.Mask = "(999)000-0000";
            TenantMskTPhoneNumber.Name = "TenantMskTPhoneNumber";
            TenantMskTPhoneNumber.Size = new Size(292, 23);
            TenantMskTPhoneNumber.TabIndex = 0;
            TenantMskTPhoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(79, 297);
            label6.Name = "label6";
            label6.Size = new Size(119, 21);
            label6.TabIndex = 72;
            label6.Text = "Documentación";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(TenantMskTDocumentation);
            panel6.Location = new Point(79, 330);
            panel6.Name = "panel6";
            panel6.Size = new Size(299, 33);
            panel6.TabIndex = 73;
            // 
            // TenantMskTDocumentation
            // 
            TenantMskTDocumentation.Location = new Point(4, 5);
            TenantMskTDocumentation.Mask = "000-0000000-0";
            TenantMskTDocumentation.Name = "TenantMskTDocumentation";
            TenantMskTDocumentation.Size = new Size(292, 23);
            TenantMskTDocumentation.TabIndex = 0;
            TenantMskTDocumentation.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(79, 218);
            label5.Name = "label5";
            label5.Size = new Size(152, 21);
            label5.TabIndex = 70;
            label5.Text = "Fecha de nacimiento";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(TenantDTPBirthdate);
            panel5.Location = new Point(79, 251);
            panel5.Name = "panel5";
            panel5.Size = new Size(299, 29);
            panel5.TabIndex = 71;
            // 
            // TenantDTPBirthdate
            // 
            TenantDTPBirthdate.Location = new Point(3, 3);
            TenantDTPBirthdate.Name = "TenantDTPBirthdate";
            TenantDTPBirthdate.Size = new Size(293, 23);
            TenantDTPBirthdate.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(79, 149);
            label3.Name = "label3";
            label3.Size = new Size(43, 21);
            label3.TabIndex = 68;
            label3.Text = "Sexo";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(TenantCBSexs);
            panel3.Location = new Point(79, 173);
            panel3.Name = "panel3";
            panel3.Size = new Size(299, 31);
            panel3.TabIndex = 69;
            // 
            // TenantCBSexs
            // 
            TenantCBSexs.DropDownStyle = ComboBoxStyle.DropDownList;
            TenantCBSexs.FormattingEnabled = true;
            TenantCBSexs.Location = new Point(4, 4);
            TenantCBSexs.Name = "TenantCBSexs";
            TenantCBSexs.Size = new Size(292, 23);
            TenantCBSexs.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(79, 79);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 66;
            label4.Text = "Apellido";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(TenantTBLastname);
            panel4.Location = new Point(79, 112);
            panel4.Name = "panel4";
            panel4.Size = new Size(299, 24);
            panel4.TabIndex = 67;
            // 
            // TenantTBLastname
            // 
            TenantTBLastname.BorderStyle = BorderStyle.None;
            TenantTBLastname.Location = new Point(4, 4);
            TenantTBLastname.Name = "TenantTBLastname";
            TenantTBLastname.Size = new Size(292, 16);
            TenantTBLastname.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(79, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 64;
            label1.Text = "Nombre";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(TenantTBName);
            panel2.Location = new Point(79, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(299, 24);
            panel2.TabIndex = 65;
            // 
            // TenantTBName
            // 
            TenantTBName.BorderStyle = BorderStyle.None;
            TenantTBName.Location = new Point(4, 4);
            TenantTBName.Name = "TenantTBName";
            TenantTBName.Size = new Size(292, 16);
            TenantTBName.TabIndex = 2;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(156, 567);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 78;
            toolTip1.SetToolTip(UpsertPNLBTN, "Guardar/Actualizar inquilino.");
            UpsertPNLBTN.Click += UpsertPNLBTN_Click;
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
            toolTip1.SetToolTip(UpsertLBLBTN, "Guardar/Actualizar inquilino.");
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
            toolTip1.SetToolTip(UpsertPCTBXBTN, "Guardar/Actualizar inquilino.");
            UpsertPCTBXBTN.Click += UpsertPNLBTN_Click;
            // 
            // UpsertTenantScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 643);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label11);
            Controls.Add(panel8);
            Controls.Add(label7);
            Controls.Add(panel7);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label5);
            Controls.Add(panel5);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(panel2);
            Name = "UpsertTenantScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpsertTenant";
            Load += UpsertTenantScreen_Load;
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private Panel panel8;
        private ComboBox TenantCBHouses;
        private Label label7;
        private Panel panel7;
        private MaskedTextBox TenantMskTPhoneNumber;
        private Label label6;
        private Panel panel6;
        private MaskedTextBox TenantMskTDocumentation;
        private Label label5;
        private Panel panel5;
        private DateTimePicker TenantDTPBirthdate;
        private Label label3;
        private Panel panel3;
        private ComboBox TenantCBSexs;
        private Label label4;
        private Panel panel4;
        private TextBox TenantTBLastname;
        private Label label1;
        private Panel panel2;
        private TextBox TenantTBName;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
        private ToolTip toolTip1;
    }
}