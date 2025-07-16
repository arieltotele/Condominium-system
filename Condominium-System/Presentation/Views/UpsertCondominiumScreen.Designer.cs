namespace Condominium_System.Presentation.Views
{
    partial class UpsertCondominiumScreen
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
            UpsertMskTBContactNumber = new MaskedTextBox();
            label5 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            UpsertTIBlocksQuantity = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            UpsertTIAddress = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            UpsertTIName = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // UpsertMskTBContactNumber
            // 
            UpsertMskTBContactNumber.Location = new Point(33, 313);
            UpsertMskTBContactNumber.Mask = "(999)000-0000";
            UpsertMskTBContactNumber.Name = "UpsertMskTBContactNumber";
            UpsertMskTBContactNumber.Size = new Size(334, 23);
            UpsertMskTBContactNumber.TabIndex = 44;
            UpsertMskTBContactNumber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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
            panel2.Controls.Add(UpsertTIBlocksQuantity);
            panel2.Location = new Point(33, 217);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 24);
            panel2.TabIndex = 42;
            // 
            // UpsertTIBlocksQuantity
            // 
            UpsertTIBlocksQuantity.BorderStyle = BorderStyle.None;
            UpsertTIBlocksQuantity.Location = new Point(4, 3);
            UpsertTIBlocksQuantity.Name = "UpsertTIBlocksQuantity";
            UpsertTIBlocksQuantity.Size = new Size(327, 16);
            UpsertTIBlocksQuantity.TabIndex = 2;
            UpsertTIBlocksQuantity.KeyPress += OnlyAllowNumbers_KeyPress;
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
            panel3.Controls.Add(UpsertTIAddress);
            panel3.Location = new Point(33, 127);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 24);
            panel3.TabIndex = 40;
            // 
            // UpsertTIAddress
            // 
            UpsertTIAddress.BorderStyle = BorderStyle.None;
            UpsertTIAddress.Location = new Point(4, 3);
            UpsertTIAddress.Name = "UpsertTIAddress";
            UpsertTIAddress.Size = new Size(327, 16);
            UpsertTIAddress.TabIndex = 2;
            UpsertTIAddress.KeyPress += OnlyAllowLetters_KeyPress;
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
            panel1.Controls.Add(UpsertTIName);
            panel1.Location = new Point(33, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 24);
            panel1.TabIndex = 38;
            // 
            // UpsertTIName
            // 
            UpsertTIName.BorderStyle = BorderStyle.None;
            UpsertTIName.Location = new Point(4, 3);
            UpsertTIName.Name = "UpsertTIName";
            UpsertTIName.Size = new Size(327, 16);
            UpsertTIName.TabIndex = 2;
            UpsertTIName.KeyPress += OnlyAllowLetters_KeyPress;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(135, 403);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 45;
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
            // UpsertCondominiumScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 491);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(UpsertMskTBContactNumber);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "UpsertCondominiumScreen";
            Text = "AddCondominiumScreen";
            Load += AddCondominiumScreen_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox UpsertMskTBContactNumber;
        private Label label5;
        private Label label3;
        private Panel panel2;
        private TextBox UpsertTIBlocksQuantity;
        private Label label4;
        private Panel panel3;
        private TextBox UpsertTIAddress;
        private Label label2;
        private Panel panel1;
        private TextBox UpsertTIName;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
    }
}