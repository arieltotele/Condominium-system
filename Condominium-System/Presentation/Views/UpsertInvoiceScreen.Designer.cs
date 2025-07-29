namespace Condominium_System.Presentation.Views
{
    partial class UpsertInvoiceScreen
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
            label6 = new Label();
            panel5 = new Panel();
            UpsertInvoiceComboBxTenants = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            UpsertInvoiceTBDescription = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            UpsertInvoiceTBTotalAmount = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(27, 9);
            label6.Name = "label6";
            label6.Size = new Size(192, 21);
            label6.TabIndex = 51;
            label6.Text = "Identificacion del inquilino";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(UpsertInvoiceComboBxTenants);
            panel5.Location = new Point(27, 42);
            panel5.Name = "panel5";
            panel5.Size = new Size(261, 30);
            panel5.TabIndex = 52;
            // 
            // UpsertInvoiceComboBxTenants
            // 
            UpsertInvoiceComboBxTenants.DropDownStyle = ComboBoxStyle.DropDownList;
            UpsertInvoiceComboBxTenants.FormattingEnabled = true;
            UpsertInvoiceComboBxTenants.Location = new Point(3, 4);
            UpsertInvoiceComboBxTenants.Name = "UpsertInvoiceComboBxTenants";
            UpsertInvoiceComboBxTenants.Size = new Size(255, 23);
            UpsertInvoiceComboBxTenants.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(27, 99);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 53;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(UpsertInvoiceTBDescription);
            panel1.Location = new Point(27, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(258, 91);
            panel1.TabIndex = 54;
            // 
            // UpsertInvoiceTBDescription
            // 
            UpsertInvoiceTBDescription.BorderStyle = BorderStyle.None;
            UpsertInvoiceTBDescription.Location = new Point(3, 4);
            UpsertInvoiceTBDescription.Multiline = true;
            UpsertInvoiceTBDescription.Name = "UpsertInvoiceTBDescription";
            UpsertInvoiceTBDescription.Size = new Size(252, 84);
            UpsertInvoiceTBDescription.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(30, 257);
            label4.Name = "label4";
            label4.Size = new Size(91, 21);
            label4.TabIndex = 55;
            label4.Text = "Monto total";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(UpsertInvoiceTBTotalAmount);
            panel3.Location = new Point(30, 290);
            panel3.Name = "panel3";
            panel3.Size = new Size(258, 24);
            panel3.TabIndex = 56;
            // 
            // UpsertInvoiceTBTotalAmount
            // 
            UpsertInvoiceTBTotalAmount.BorderStyle = BorderStyle.None;
            UpsertInvoiceTBTotalAmount.Location = new Point(4, 4);
            UpsertInvoiceTBTotalAmount.Name = "UpsertInvoiceTBTotalAmount";
            UpsertInvoiceTBTotalAmount.Size = new Size(251, 16);
            UpsertInvoiceTBTotalAmount.TabIndex = 2;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(89, 376);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 71;
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
            // UpsertInvoiceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 450);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(panel5);
            Name = "UpsertInvoiceScreen";
            Text = "UpsertInvoice";
            Load += UpsertInvoiceScreen_Load;
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Panel panel5;
        private ComboBox UpsertInvoiceComboBxTenants;
        private Label label2;
        private Panel panel1;
        private TextBox UpsertInvoiceTBDescription;
        private Label label4;
        private Panel panel3;
        private TextBox UpsertInvoiceTBTotalAmount;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
    }
}