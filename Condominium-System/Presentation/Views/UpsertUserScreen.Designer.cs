namespace Condominium_System.Presentation.Views
{
    partial class UpsertUserScreen
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
            label9 = new Label();
            panel7 = new Panel();
            UserTBCondominium = new ComboBox();
            UserMskTbContactNumber = new MaskedTextBox();
            label8 = new Label();
            label7 = new Label();
            panel4 = new Panel();
            UserTbPassword = new TextBox();
            label5 = new Label();
            panel5 = new Panel();
            UserCbType = new ComboBox();
            label6 = new Label();
            panel6 = new Panel();
            UserMskTbDocumentation = new MaskedTextBox();
            label3 = new Label();
            panel3 = new Panel();
            UserTxtBxPUsername = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            UserTxtBxPLastname = new TextBox();
            label4 = new Label();
            panel2 = new Panel();
            UserTxtBxPName = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(16, 276);
            label9.Name = "label9";
            label9.Size = new Size(96, 21);
            label9.TabIndex = 168;
            label9.Text = "Condominio";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.Controls.Add(UserTBCondominium);
            panel7.Location = new Point(16, 309);
            panel7.Name = "panel7";
            panel7.Size = new Size(208, 30);
            panel7.TabIndex = 169;
            // 
            // UserTBCondominium
            // 
            UserTBCondominium.DropDownStyle = ComboBoxStyle.DropDownList;
            UserTBCondominium.FormattingEnabled = true;
            UserTBCondominium.Location = new Point(3, 4);
            UserTBCondominium.Name = "UserTBCondominium";
            UserTBCondominium.Size = new Size(202, 23);
            UserTBCondominium.TabIndex = 0;
            // 
            // UserMskTbContactNumber
            // 
            UserMskTbContactNumber.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            UserMskTbContactNumber.Location = new Point(289, 219);
            UserMskTbContactNumber.Mask = "(999)000-0000";
            UserMskTbContactNumber.Name = "UserMskTbContactNumber";
            UserMskTbContactNumber.Size = new Size(212, 23);
            UserMskTbContactNumber.TabIndex = 167;
            UserMskTbContactNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(289, 182);
            label8.Name = "label8";
            label8.Size = new Size(152, 21);
            label8.TabIndex = 166;
            label8.Text = "Número de contacto";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(289, 88);
            label7.Name = "label7";
            label7.Size = new Size(89, 21);
            label7.TabIndex = 164;
            label7.Text = "Contraseña";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(UserTbPassword);
            panel4.Location = new Point(289, 121);
            panel4.Name = "panel4";
            panel4.Size = new Size(211, 24);
            panel4.TabIndex = 165;
            // 
            // UserTbPassword
            // 
            UserTbPassword.BorderStyle = BorderStyle.None;
            UserTbPassword.Location = new Point(4, 4);
            UserTbPassword.Name = "UserTbPassword";
            UserTbPassword.Size = new Size(208, 16);
            UserTbPassword.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(293, 276);
            label5.Name = "label5";
            label5.Size = new Size(40, 21);
            label5.TabIndex = 162;
            label5.Text = "Tipo";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(UserCbType);
            panel5.Location = new Point(293, 309);
            panel5.Name = "panel5";
            panel5.Size = new Size(207, 30);
            panel5.TabIndex = 163;
            // 
            // UserCbType
            // 
            UserCbType.DropDownStyle = ComboBoxStyle.DropDownList;
            UserCbType.FlatStyle = FlatStyle.Flat;
            UserCbType.FormattingEnabled = true;
            UserCbType.Location = new Point(3, 4);
            UserCbType.Name = "UserCbType";
            UserCbType.Size = new Size(201, 23);
            UserCbType.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 182);
            label6.Name = "label6";
            label6.Size = new Size(119, 21);
            label6.TabIndex = 160;
            label6.Text = "Documentación";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(UserMskTbDocumentation);
            panel6.Location = new Point(12, 215);
            panel6.Name = "panel6";
            panel6.Size = new Size(215, 33);
            panel6.TabIndex = 161;
            // 
            // UserMskTbDocumentation
            // 
            UserMskTbDocumentation.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            UserMskTbDocumentation.Location = new Point(4, 5);
            UserMskTbDocumentation.Mask = "000-0000000-0";
            UserMskTbDocumentation.Name = "UserMskTbDocumentation";
            UserMskTbDocumentation.Size = new Size(208, 23);
            UserMskTbDocumentation.TabIndex = 0;
            UserMskTbDocumentation.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(145, 21);
            label3.TabIndex = 158;
            label3.Text = "Nombre de usuario";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(UserTxtBxPUsername);
            panel3.Location = new Point(12, 121);
            panel3.Name = "panel3";
            panel3.Size = new Size(215, 24);
            panel3.TabIndex = 159;
            // 
            // UserTxtBxPUsername
            // 
            UserTxtBxPUsername.BorderStyle = BorderStyle.None;
            UserTxtBxPUsername.Location = new Point(4, 4);
            UserTxtBxPUsername.Name = "UserTxtBxPUsername";
            UserTxtBxPUsername.Size = new Size(208, 16);
            UserTxtBxPUsername.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(289, 9);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 156;
            label2.Text = "Apellido";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(UserTxtBxPLastname);
            panel1.Location = new Point(289, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 24);
            panel1.TabIndex = 157;
            // 
            // UserTxtBxPLastname
            // 
            UserTxtBxPLastname.BorderStyle = BorderStyle.None;
            UserTxtBxPLastname.Location = new Point(4, 4);
            UserTxtBxPLastname.Name = "UserTxtBxPLastname";
            UserTxtBxPLastname.Size = new Size(204, 16);
            UserTxtBxPLastname.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(68, 21);
            label4.TabIndex = 154;
            label4.Text = "Nombre";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(UserTxtBxPName);
            panel2.Location = new Point(12, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(215, 24);
            panel2.TabIndex = 155;
            // 
            // UserTxtBxPName
            // 
            UserTxtBxPName.BorderStyle = BorderStyle.None;
            UserTxtBxPName.Location = new Point(4, 4);
            UserTxtBxPName.Name = "UserTxtBxPName";
            UserTxtBxPName.Size = new Size(208, 16);
            UserTxtBxPName.TabIndex = 2;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(194, 429);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 170;
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
            // 
            // UpsertUserScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 505);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label9);
            Controls.Add(panel7);
            Controls.Add(UserMskTbContactNumber);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(panel4);
            Controls.Add(label5);
            Controls.Add(panel5);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(panel2);
            Name = "UpsertUserScreen";
            Text = "UpsertUserScreen";
            Load += UpsertUserScreen_Load;
            panel7.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Panel panel7;
        private ComboBox UserTBCondominium;
        private MaskedTextBox UserMskTbContactNumber;
        private Label label8;
        private Label label7;
        private Panel panel4;
        private TextBox UserTbPassword;
        private Label label5;
        private Panel panel5;
        private ComboBox UserCbType;
        private Label label6;
        private Panel panel6;
        private MaskedTextBox UserMskTbDocumentation;
        private Label label3;
        private Panel panel3;
        private TextBox UserTxtBxPUsername;
        private Label label2;
        private Panel panel1;
        private TextBox UserTxtBxPLastname;
        private Label label4;
        private Panel panel2;
        private TextBox UserTxtBxPName;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
    }
}