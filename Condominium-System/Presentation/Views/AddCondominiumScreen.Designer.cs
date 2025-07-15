namespace Condominium_System.Presentation.Views
{
    partial class AddCondominiumScreen
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
            CondominiumMskTBContactNumber = new MaskedTextBox();
            label5 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            CondominiumTIBlocksQuantity = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            CondominiumTIAddress = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            CondominiumTIName = new TextBox();
            CondominiumPNLBTNUpdate = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            CondominiumPNLBTNUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CondominiumMskTBContactNumber
            // 
            CondominiumMskTBContactNumber.Location = new Point(33, 313);
            CondominiumMskTBContactNumber.Mask = "(999)000-0000";
            CondominiumMskTBContactNumber.Name = "CondominiumMskTBContactNumber";
            CondominiumMskTBContactNumber.Size = new Size(334, 23);
            CondominiumMskTBContactNumber.TabIndex = 44;
            CondominiumMskTBContactNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(33, 276);
            label5.Name = "label5";
            label5.Size = new Size(152, 21);
            label5.TabIndex = 43;
            label5.Text = "Número de contacto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(33, 184);
            label3.Name = "label3";
            label3.Size = new Size(152, 21);
            label3.TabIndex = 41;
            label3.Text = "Cantidad de bloques";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(CondominiumTIBlocksQuantity);
            panel2.Location = new Point(33, 217);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 24);
            panel2.TabIndex = 42;
            // 
            // CondominiumTIBlocksQuantity
            // 
            CondominiumTIBlocksQuantity.BorderStyle = BorderStyle.None;
            CondominiumTIBlocksQuantity.Location = new Point(4, 3);
            CondominiumTIBlocksQuantity.Name = "CondominiumTIBlocksQuantity";
            CondominiumTIBlocksQuantity.Size = new Size(327, 16);
            CondominiumTIBlocksQuantity.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(33, 94);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 39;
            label4.Text = "Dirección";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(CondominiumTIAddress);
            panel3.Location = new Point(33, 127);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 24);
            panel3.TabIndex = 40;
            // 
            // CondominiumTIAddress
            // 
            CondominiumTIAddress.BorderStyle = BorderStyle.None;
            CondominiumTIAddress.Location = new Point(4, 3);
            CondominiumTIAddress.Name = "CondominiumTIAddress";
            CondominiumTIAddress.Size = new Size(327, 16);
            CondominiumTIAddress.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(33, 9);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 37;
            label2.Text = "Nombre";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(CondominiumTIName);
            panel1.Location = new Point(33, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 24);
            panel1.TabIndex = 38;
            // 
            // CondominiumTIName
            // 
            CondominiumTIName.BorderStyle = BorderStyle.None;
            CondominiumTIName.Location = new Point(4, 3);
            CondominiumTIName.Name = "CondominiumTIName";
            CondominiumTIName.Size = new Size(327, 16);
            CondominiumTIName.TabIndex = 2;
            // 
            // CondominiumPNLBTNUpdate
            // 
            CondominiumPNLBTNUpdate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNUpdate.Controls.Add(label6);
            CondominiumPNLBTNUpdate.Controls.Add(pictureBox1);
            CondominiumPNLBTNUpdate.Location = new Point(133, 408);
            CondominiumPNLBTNUpdate.Name = "CondominiumPNLBTNUpdate";
            CondominiumPNLBTNUpdate.Size = new Size(119, 41);
            CondominiumPNLBTNUpdate.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(39, 12);
            label6.Name = "label6";
            label6.Size = new Size(78, 21);
            label6.TabIndex = 1;
            label6.Text = "Actualizar";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.pencil_white;
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AddCondominiumScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 491);
            Controls.Add(CondominiumPNLBTNUpdate);
            Controls.Add(CondominiumMskTBContactNumber);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "AddCondominiumScreen";
            Text = "AddCondominiumScreen";
            Load += AddCondominiumScreen_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            CondominiumPNLBTNUpdate.ResumeLayout(false);
            CondominiumPNLBTNUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox CondominiumMskTBContactNumber;
        private Label label5;
        private Label label3;
        private Panel panel2;
        private TextBox CondominiumTIBlocksQuantity;
        private Label label4;
        private Panel panel3;
        private TextBox CondominiumTIAddress;
        private Label label2;
        private Panel panel1;
        private TextBox CondominiumTIName;
        private Panel CondominiumPNLBTNUpdate;
        private Label label6;
        private PictureBox pictureBox1;
    }
}