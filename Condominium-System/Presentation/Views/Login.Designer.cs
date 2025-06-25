namespace Condominium_System.Presentation.Views
{
    partial class Login
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            LoginTxtBxPUsername = new TextBox();
            LoginPNLUsername = new Panel();
            LoginBTNLogIn = new Button();
            label2 = new Label();
            LoginPNLPassword = new Panel();
            LoginTxtBxPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            LoginPNLUsername.SuspendLayout();
            LoginPNLPassword.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(87, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(333, 323);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(87, 414);
            label1.Name = "label1";
            label1.Size = new Size(145, 21);
            label1.TabIndex = 1;
            label1.Text = "Nombre de usuario";
            // 
            // LoginTxtBxPUsername
            // 
            LoginTxtBxPUsername.BorderStyle = BorderStyle.None;
            LoginTxtBxPUsername.Location = new Point(4, 3);
            LoginTxtBxPUsername.Name = "LoginTxtBxPUsername";
            LoginTxtBxPUsername.Size = new Size(360, 16);
            LoginTxtBxPUsername.TabIndex = 2;
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(LoginTxtBxPUsername);
            LoginPNLUsername.Location = new Point(87, 447);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(367, 24);
            LoginPNLUsername.TabIndex = 3;
            // 
            // LoginBTNLogIn
            // 
            LoginBTNLogIn.BackColor = Color.MidnightBlue;
            LoginBTNLogIn.ForeColor = Color.White;
            LoginBTNLogIn.Location = new Point(184, 621);
            LoginBTNLogIn.Name = "LoginBTNLogIn";
            LoginBTNLogIn.Size = new Size(118, 48);
            LoginBTNLogIn.TabIndex = 6;
            LoginBTNLogIn.Text = "Iniciar Sesion";
            LoginBTNLogIn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(87, 507);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 7;
            label2.Text = "Contraseña";
            // 
            // LoginPNLPassword
            // 
            LoginPNLPassword.BackColor = SystemColors.Window;
            LoginPNLPassword.Controls.Add(LoginTxtBxPassword);
            LoginPNLPassword.Location = new Point(87, 540);
            LoginPNLPassword.Name = "LoginPNLPassword";
            LoginPNLPassword.Size = new Size(367, 24);
            LoginPNLPassword.TabIndex = 8;
            // 
            // LoginTxtBxPassword
            // 
            LoginTxtBxPassword.BorderStyle = BorderStyle.None;
            LoginTxtBxPassword.Location = new Point(4, 3);
            LoginTxtBxPassword.Name = "LoginTxtBxPassword";
            LoginTxtBxPassword.PasswordChar = '*';
            LoginTxtBxPassword.Size = new Size(360, 16);
            LoginTxtBxPassword.TabIndex = 2;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 750);
            Controls.Add(label2);
            Controls.Add(LoginPNLPassword);
            Controls.Add(LoginBTNLogIn);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(LoginPNLUsername);
            Name = "Login";
            Text = "Iniciar Sesion";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            LoginPNLPassword.ResumeLayout(false);
            LoginPNLPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox LoginTxtBxPUsername;
        private Panel LoginPNLUsername;
        private Button LoginBTNLogIn;
        private Label label2;
        private Panel LoginPNLPassword;
        private TextBox LoginTxtBxPassword;
    }
}