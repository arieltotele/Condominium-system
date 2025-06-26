namespace Condominium_System.Presentation.Views
{
    partial class IncidenceScreen
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
            LoginTxtBxPUsername = new TextBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            panel5 = new Panel();
            maskedTextBox1 = new MaskedTextBox();
            label6 = new Label();
            panel6 = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label13 = new Label();
            pictureBox4 = new PictureBox();
            CondominiumPNLBTNDelete = new Panel();
            label10 = new Label();
            pictureBox1 = new PictureBox();
            CondominiumPNLBTNUpdate = new Panel();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            CondominiumPNLBTNSearch = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            dataGridView1 = new DataGridView();
            CondominiumPNLBTNCreate = new Panel();
            LoginPNLUsername = new Panel();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            CondominiumPNLBTNDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CondominiumPNLBTNUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            CondominiumPNLBTNSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            CondominiumPNLBTNCreate.SuspendLayout();
            LoginPNLUsername.SuspendLayout();
            SuspendLayout();
            // 
            // LoginTxtBxPUsername
            // 
            LoginTxtBxPUsername.BorderStyle = BorderStyle.None;
            LoginTxtBxPUsername.Location = new Point(4, 4);
            LoginTxtBxPUsername.Name = "LoginTxtBxPUsername";
            LoginTxtBxPUsername.Size = new Size(327, 16);
            LoginTxtBxPUsername.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(21, 10);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 93;
            label1.Text = "ID";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(3, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(226, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(189, 10);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 95;
            label5.Text = "Fecha";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(dateTimePicker1);
            panel5.Location = new Point(189, 43);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 29);
            panel5.TabIndex = 96;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(4, 5);
            maskedTextBox1.Mask = "000-0000000-0";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(223, 23);
            maskedTextBox1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(471, 10);
            label6.Name = "label6";
            label6.Size = new Size(209, 21);
            label6.TabIndex = 97;
            label6.Text = "Documentación del inquilino";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(maskedTextBox1);
            panel6.Location = new Point(471, 43);
            panel6.Name = "panel6";
            panel6.Size = new Size(230, 33);
            panel6.TabIndex = 98;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(4, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(232, 57);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(757, 10);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 99;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(757, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 68);
            panel1.TabIndex = 100;
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
            // 
            // CondominiumPNLBTNDelete
            // 
            CondominiumPNLBTNDelete.BackColor = Color.FromArgb(199, 0, 0);
            CondominiumPNLBTNDelete.Controls.Add(label13);
            CondominiumPNLBTNDelete.Controls.Add(pictureBox4);
            CondominiumPNLBTNDelete.Location = new Point(714, 186);
            CondominiumPNLBTNDelete.Name = "CondominiumPNLBTNDelete";
            CondominiumPNLBTNDelete.Size = new Size(109, 41);
            CondominiumPNLBTNDelete.TabIndex = 101;
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
            // 
            // CondominiumPNLBTNUpdate
            // 
            CondominiumPNLBTNUpdate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNUpdate.Controls.Add(label10);
            CondominiumPNLBTNUpdate.Controls.Add(pictureBox1);
            CondominiumPNLBTNUpdate.Location = new Point(544, 186);
            CondominiumPNLBTNUpdate.Name = "CondominiumPNLBTNUpdate";
            CondominiumPNLBTNUpdate.Size = new Size(119, 41);
            CondominiumPNLBTNUpdate.TabIndex = 102;
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
            // 
            // CondominiumPNLBTNSearch
            // 
            CondominiumPNLBTNSearch.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNSearch.Controls.Add(label9);
            CondominiumPNLBTNSearch.Controls.Add(pictureBox2);
            CondominiumPNLBTNSearch.Location = new Point(374, 186);
            CondominiumPNLBTNSearch.Name = "CondominiumPNLBTNSearch";
            CondominiumPNLBTNSearch.Size = new Size(109, 41);
            CondominiumPNLBTNSearch.TabIndex = 103;
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
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 271);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(945, 309);
            dataGridView1.TabIndex = 105;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(217, 186);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 104;
            // 
            // LoginPNLUsername
            // 
            LoginPNLUsername.BackColor = SystemColors.Window;
            LoginPNLUsername.Controls.Add(LoginTxtBxPUsername);
            LoginPNLUsername.Location = new Point(21, 43);
            LoginPNLUsername.Name = "LoginPNLUsername";
            LoginPNLUsername.Size = new Size(119, 24);
            LoginPNLUsername.TabIndex = 94;
            // 
            // IncidenceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(panel5);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(CondominiumPNLBTNDelete);
            Controls.Add(CondominiumPNLBTNUpdate);
            Controls.Add(CondominiumPNLBTNSearch);
            Controls.Add(dataGridView1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(LoginPNLUsername);
            Name = "IncidenceScreen";
            Text = "IncidenceScreen";
            Load += IncidenceScreen_Load;
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            CondominiumPNLBTNDelete.ResumeLayout(false);
            CondominiumPNLBTNDelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            CondominiumPNLBTNUpdate.ResumeLayout(false);
            CondominiumPNLBTNUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            CondominiumPNLBTNSearch.ResumeLayout(false);
            CondominiumPNLBTNSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            LoginPNLUsername.ResumeLayout(false);
            LoginPNLUsername.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTxtBxPUsername;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private Panel panel5;
        private MaskedTextBox maskedTextBox1;
        private Label label6;
        private Panel panel6;
        private TextBox textBox1;
        private Label label2;
        private Panel panel1;
        private Label label13;
        private PictureBox pictureBox4;
        private Panel CondominiumPNLBTNDelete;
        private Label label10;
        private PictureBox pictureBox1;
        private Panel CondominiumPNLBTNUpdate;
        private Label label9;
        private PictureBox pictureBox2;
        private Panel CondominiumPNLBTNSearch;
        private Label label8;
        private PictureBox pictureBox3;
        private DataGridView dataGridView1;
        private Panel CondominiumPNLBTNCreate;
        private Panel LoginPNLUsername;
    }
}