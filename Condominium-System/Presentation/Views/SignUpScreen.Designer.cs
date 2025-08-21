namespace Condominium_System.Presentation.Views
{
    partial class SignUpScreen
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
            pictureBox1 = new PictureBox();
            SignUpTitleLBL = new Label();
            label2 = new Label();
            SignUpPNLName = new Panel();
            SignUpTxtBxName = new TextBox();
            label3 = new Label();
            SignUpPNLLastname = new Panel();
            SignUpTxtBxLastname = new TextBox();
            label4 = new Label();
            panel1 = new Panel();
            SignUpTxtBxUsername = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            SignUpTxtBxConfirmPassword = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            SignUpTxtBxPassword = new TextBox();
            label7 = new Label();
            panel4 = new Panel();
            SignUpMskTBDocumentNumber = new MaskedTextBox();
            label8 = new Label();
            panel5 = new Panel();
            SignUpMskTBTelephoneNumber = new MaskedTextBox();
            label9 = new Label();
            label10 = new Label();
            SignUpComboBxCondominium = new ComboBox();
            SignUpComboBxType = new ComboBox();
            SignUpPNLBTNBack = new Panel();
            label11 = new Label();
            pictureBox2 = new PictureBox();
            SignUpPNLBTNClean = new Panel();
            label12 = new Label();
            pictureBox3 = new PictureBox();
            SignUpPNLBTNSave = new Panel();
            label13 = new Label();
            pictureBox4 = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SignUpPNLName.SuspendLayout();
            SignUpPNLLastname.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SignUpPNLBTNBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SignUpPNLBTNClean.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SignUpPNLBTNSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.add_user;
            pictureBox1.Location = new Point(0, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(305, 366);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // SignUpTitleLBL
            // 
            SignUpTitleLBL.AutoSize = true;
            SignUpTitleLBL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SignUpTitleLBL.Location = new Point(439, 9);
            SignUpTitleLBL.Name = "SignUpTitleLBL";
            SignUpTitleLBL.Size = new Size(129, 21);
            SignUpTitleLBL.TabIndex = 1;
            SignUpTitleLBL.Text = "Registrar usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(336, 55);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 9;
            label2.Text = "Nombre";
            // 
            // SignUpPNLName
            // 
            SignUpPNLName.BackColor = SystemColors.Window;
            SignUpPNLName.Controls.Add(SignUpTxtBxName);
            SignUpPNLName.Location = new Point(336, 88);
            SignUpPNLName.Name = "SignUpPNLName";
            SignUpPNLName.Size = new Size(295, 24);
            SignUpPNLName.TabIndex = 10;
            // 
            // SignUpTxtBxName
            // 
            SignUpTxtBxName.BorderStyle = BorderStyle.None;
            SignUpTxtBxName.Location = new Point(4, 3);
            SignUpTxtBxName.Name = "SignUpTxtBxName";
            SignUpTxtBxName.Size = new Size(288, 16);
            SignUpTxtBxName.TabIndex = 2;
            SignUpTxtBxName.KeyPress += SignUpTxtBxName_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(337, 127);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 11;
            label3.Text = "Apellido";
            // 
            // SignUpPNLLastname
            // 
            SignUpPNLLastname.BackColor = SystemColors.Window;
            SignUpPNLLastname.Controls.Add(SignUpTxtBxLastname);
            SignUpPNLLastname.Location = new Point(337, 160);
            SignUpPNLLastname.Name = "SignUpPNLLastname";
            SignUpPNLLastname.Size = new Size(295, 24);
            SignUpPNLLastname.TabIndex = 12;
            // 
            // SignUpTxtBxLastname
            // 
            SignUpTxtBxLastname.BorderStyle = BorderStyle.None;
            SignUpTxtBxLastname.Location = new Point(4, 3);
            SignUpTxtBxLastname.Name = "SignUpTxtBxLastname";
            SignUpTxtBxLastname.Size = new Size(288, 16);
            SignUpTxtBxLastname.TabIndex = 2;
            SignUpTxtBxLastname.KeyPress += SignUpTxtBxLastname_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(337, 205);
            label4.Name = "label4";
            label4.Size = new Size(147, 21);
            label4.TabIndex = 13;
            label4.Text = "Nombre de Usuario";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(SignUpTxtBxUsername);
            panel1.Location = new Point(337, 238);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 24);
            panel1.TabIndex = 14;
            // 
            // SignUpTxtBxUsername
            // 
            SignUpTxtBxUsername.BorderStyle = BorderStyle.None;
            SignUpTxtBxUsername.Location = new Point(4, 3);
            SignUpTxtBxUsername.Name = "SignUpTxtBxUsername";
            SignUpTxtBxUsername.Size = new Size(288, 16);
            SignUpTxtBxUsername.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(337, 443);
            label5.Name = "label5";
            label5.Size = new Size(161, 21);
            label5.TabIndex = 19;
            label5.Text = "Confirmar contraseña";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(SignUpTxtBxConfirmPassword);
            panel2.Location = new Point(337, 476);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 24);
            panel2.TabIndex = 20;
            // 
            // SignUpTxtBxConfirmPassword
            // 
            SignUpTxtBxConfirmPassword.BorderStyle = BorderStyle.None;
            SignUpTxtBxConfirmPassword.Location = new Point(4, 3);
            SignUpTxtBxConfirmPassword.Name = "SignUpTxtBxConfirmPassword";
            SignUpTxtBxConfirmPassword.PasswordChar = '*';
            SignUpTxtBxConfirmPassword.Size = new Size(288, 16);
            SignUpTxtBxConfirmPassword.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(337, 360);
            label6.Name = "label6";
            label6.Size = new Size(89, 21);
            label6.TabIndex = 17;
            label6.Text = "Contraseña";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(SignUpTxtBxPassword);
            panel3.Location = new Point(337, 393);
            panel3.Name = "panel3";
            panel3.Size = new Size(295, 24);
            panel3.TabIndex = 18;
            // 
            // SignUpTxtBxPassword
            // 
            SignUpTxtBxPassword.BorderStyle = BorderStyle.None;
            SignUpTxtBxPassword.Location = new Point(4, 3);
            SignUpTxtBxPassword.Name = "SignUpTxtBxPassword";
            SignUpTxtBxPassword.PasswordChar = '*';
            SignUpTxtBxPassword.Size = new Size(288, 16);
            SignUpTxtBxPassword.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(336, 282);
            label7.Name = "label7";
            label7.Size = new Size(172, 21);
            label7.TabIndex = 15;
            label7.Text = "Numero de documento";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(SignUpMskTBDocumentNumber);
            panel4.Location = new Point(336, 315);
            panel4.Name = "panel4";
            panel4.Size = new Size(295, 24);
            panel4.TabIndex = 16;
            // 
            // SignUpMskTBDocumentNumber
            // 
            SignUpMskTBDocumentNumber.Location = new Point(0, 0);
            SignUpMskTBDocumentNumber.Mask = "000-0000000-0";
            SignUpMskTBDocumentNumber.Name = "SignUpMskTBDocumentNumber";
            SignUpMskTBDocumentNumber.Size = new Size(295, 23);
            SignUpMskTBDocumentNumber.TabIndex = 0;
            SignUpMskTBDocumentNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(337, 527);
            label8.Name = "label8";
            label8.Size = new Size(150, 21);
            label8.TabIndex = 21;
            label8.Text = "Numero de telefono";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(SignUpMskTBTelephoneNumber);
            panel5.Location = new Point(337, 560);
            panel5.Name = "panel5";
            panel5.Size = new Size(295, 24);
            panel5.TabIndex = 22;
            // 
            // SignUpMskTBTelephoneNumber
            // 
            SignUpMskTBTelephoneNumber.Location = new Point(0, 0);
            SignUpMskTBTelephoneNumber.Mask = "(999)000-0000";
            SignUpMskTBTelephoneNumber.Name = "SignUpMskTBTelephoneNumber";
            SignUpMskTBTelephoneNumber.Size = new Size(295, 23);
            SignUpMskTBTelephoneNumber.TabIndex = 23;
            SignUpMskTBTelephoneNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(336, 608);
            label9.Name = "label9";
            label9.Size = new Size(40, 21);
            label9.TabIndex = 23;
            label9.Text = "Tipo";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(337, 688);
            label10.Name = "label10";
            label10.Size = new Size(96, 21);
            label10.TabIndex = 25;
            label10.Text = "Condominio";
            // 
            // SignUpComboBxCondominium
            // 
            SignUpComboBxCondominium.DropDownStyle = ComboBoxStyle.DropDownList;
            SignUpComboBxCondominium.FormattingEnabled = true;
            SignUpComboBxCondominium.Location = new Point(340, 732);
            SignUpComboBxCondominium.Name = "SignUpComboBxCondominium";
            SignUpComboBxCondominium.Size = new Size(293, 23);
            SignUpComboBxCondominium.TabIndex = 24;
            // 
            // SignUpComboBxType
            // 
            SignUpComboBxType.DropDownStyle = ComboBoxStyle.DropDownList;
            SignUpComboBxType.FormattingEnabled = true;
            SignUpComboBxType.Location = new Point(342, 646);
            SignUpComboBxType.Name = "SignUpComboBxType";
            SignUpComboBxType.Size = new Size(293, 23);
            SignUpComboBxType.TabIndex = 24;
            // 
            // SignUpPNLBTNBack
            // 
            SignUpPNLBTNBack.BackColor = Color.MidnightBlue;
            SignUpPNLBTNBack.Controls.Add(label11);
            SignUpPNLBTNBack.Controls.Add(pictureBox2);
            SignUpPNLBTNBack.Location = new Point(21, 853);
            SignUpPNLBTNBack.Name = "SignUpPNLBTNBack";
            SignUpPNLBTNBack.Size = new Size(102, 41);
            SignUpPNLBTNBack.TabIndex = 29;
            toolTip1.SetToolTip(SignUpPNLBTNBack, "Ir atras.");
            SignUpPNLBTNBack.Click += SignUpPNLBTNBack_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(39, 12);
            label11.Name = "label11";
            label11.Size = new Size(46, 21);
            label11.TabIndex = 1;
            label11.Text = "Atras";
            toolTip1.SetToolTip(label11, "Ir atras.");
            label11.Click += SignUpPNLBTNBack_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.back_white;
            pictureBox2.Location = new Point(3, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 19);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Ir atras.");
            pictureBox2.Click += SignUpPNLBTNBack_Click;
            // 
            // SignUpPNLBTNClean
            // 
            SignUpPNLBTNClean.BackColor = Color.MidnightBlue;
            SignUpPNLBTNClean.Controls.Add(label12);
            SignUpPNLBTNClean.Controls.Add(pictureBox3);
            SignUpPNLBTNClean.Location = new Point(295, 853);
            SignUpPNLBTNClean.Name = "SignUpPNLBTNClean";
            SignUpPNLBTNClean.Size = new Size(109, 41);
            SignUpPNLBTNClean.TabIndex = 30;
            toolTip1.SetToolTip(SignUpPNLBTNClean, "Limpiar los campos del formulario.+");
            SignUpPNLBTNClean.Click += SignUpPNLBTNClear_Click;
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
            toolTip1.SetToolTip(label12, "Limpiar los campos del formulario.+");
            label12.Click += SignUpPNLBTNClear_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Limpiar los campos del formulario.+");
            pictureBox3.Click += SignUpPNLBTNClear_Click;
            // 
            // SignUpPNLBTNSave
            // 
            SignUpPNLBTNSave.BackColor = Color.MidnightBlue;
            SignUpPNLBTNSave.Controls.Add(label13);
            SignUpPNLBTNSave.Controls.Add(pictureBox4);
            SignUpPNLBTNSave.Location = new Point(526, 853);
            SignUpPNLBTNSave.Name = "SignUpPNLBTNSave";
            SignUpPNLBTNSave.Size = new Size(109, 41);
            SignUpPNLBTNSave.TabIndex = 31;
            toolTip1.SetToolTip(SignUpPNLBTNSave, "Guardar usuario.");
            SignUpPNLBTNSave.Click += SignUpPNLBTNSave_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(39, 12);
            label13.Name = "label13";
            label13.Size = new Size(67, 21);
            label13.TabIndex = 1;
            label13.Text = "Guardar";
            toolTip1.SetToolTip(label13, "Guardar usuario.");
            label13.Click += SignUpPNLBTNSave_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.save_white;
            pictureBox4.Location = new Point(3, 12);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 19);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            toolTip1.SetToolTip(pictureBox4, "Guardar usuario.");
            pictureBox4.Click += SignUpPNLBTNSave_Click;
            // 
            // SignUpScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 906);
            Controls.Add(SignUpPNLBTNSave);
            Controls.Add(SignUpPNLBTNClean);
            Controls.Add(SignUpPNLBTNBack);
            Controls.Add(SignUpComboBxType);
            Controls.Add(SignUpComboBxCondominium);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(panel5);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(label6);
            Controls.Add(panel3);
            Controls.Add(label7);
            Controls.Add(panel4);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(SignUpPNLLastname);
            Controls.Add(label2);
            Controls.Add(SignUpPNLName);
            Controls.Add(SignUpTitleLBL);
            Controls.Add(pictureBox1);
            Name = "SignUpScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar";
            toolTip1.SetToolTip(this, "Limpiar los campos del formulario.+");
            Load += SignUp_Load;
            Click += SignUpPNLBTNClear_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SignUpPNLName.ResumeLayout(false);
            SignUpPNLName.PerformLayout();
            SignUpPNLLastname.ResumeLayout(false);
            SignUpPNLLastname.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            SignUpPNLBTNBack.ResumeLayout(false);
            SignUpPNLBTNBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            SignUpPNLBTNClean.ResumeLayout(false);
            SignUpPNLBTNClean.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            SignUpPNLBTNSave.ResumeLayout(false);
            SignUpPNLBTNSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label SignUpTitleLBL;
        private Label label2;
        private Panel SignUpPNLName;
        private TextBox SignUpTxtBxName;
        private Label label3;
        private Panel SignUpPNLLastname;
        private TextBox SignUpTxtBxLastname;
        private Label label4;
        private Panel panel1;
        private TextBox SignUpTxtBxUsername;
        private Label label5;
        private Panel panel2;
        private TextBox SignUpTxtBxConfirmPassword;
        private Label label6;
        private Panel panel3;
        private TextBox SignUpTxtBxPassword;
        private Label label7;
        private Panel panel4;
        private Label label8;
        private Panel panel5;
        private MaskedTextBox SignUpMskTBTelephoneNumber;
        private MaskedTextBox SignUpMskTBDocumentNumber;
        private Label label9;
        private Label label10;
        private ComboBox SignUpComboBxCondominium;
        private ComboBox SignUpComboBxType;
        private Panel SignUpPNLBTNBack;
        private Label label11;
        private PictureBox pictureBox2;
        private Panel SignUpPNLBTNClean;
        private Label label12;
        private PictureBox pictureBox3;
        private Panel SignUpPNLBTNSave;
        private Label label13;
        private PictureBox pictureBox4;
        private ToolTip toolTip1;
    }
}