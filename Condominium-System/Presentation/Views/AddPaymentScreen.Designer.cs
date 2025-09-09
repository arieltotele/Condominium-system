namespace Condominium_System.Presentation.Views
{
    partial class AddPaymentScreen
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
            UpsertPNLBTN = new Panel();
            PaymentSaveBTNLBL = new Label();
            UpsertPCTBXBTN = new PictureBox();
            label4 = new Label();
            panel3 = new Panel();
            PaymentCBDetail = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            PaymentTBAmount = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            PaymentCBPayMethod = new ComboBox();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(PaymentSaveBTNLBL);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(102, 465);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(137, 41);
            UpsertPNLBTN.TabIndex = 139;
            UpsertPNLBTN.Click += PaymentSaveBTN_Click;
            // 
            // PaymentSaveBTNLBL
            // 
            PaymentSaveBTNLBL.AutoSize = true;
            PaymentSaveBTNLBL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PaymentSaveBTNLBL.ForeColor = Color.White;
            PaymentSaveBTNLBL.Location = new Point(39, 12);
            PaymentSaveBTNLBL.Name = "PaymentSaveBTNLBL";
            PaymentSaveBTNLBL.Size = new Size(67, 21);
            PaymentSaveBTNLBL.TabIndex = 1;
            PaymentSaveBTNLBL.Text = "Guardar";
            PaymentSaveBTNLBL.Click += PaymentSaveBTN_Click;
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
            UpsertPCTBXBTN.Click += PaymentSaveBTN_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(58, 207);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 133;
            label4.Text = "Detalles";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(PaymentCBDetail);
            panel3.Location = new Point(58, 240);
            panel3.Name = "panel3";
            panel3.Size = new Size(232, 193);
            panel3.TabIndex = 134;
            // 
            // PaymentCBDetail
            // 
            PaymentCBDetail.BorderStyle = BorderStyle.None;
            PaymentCBDetail.Location = new Point(4, 4);
            PaymentCBDetail.Multiline = true;
            PaymentCBDetail.Name = "PaymentCBDetail";
            PaymentCBDetail.Size = new Size(225, 186);
            PaymentCBDetail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(58, 18);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 129;
            label2.Text = "Monto";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(PaymentTBAmount);
            panel1.Location = new Point(58, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 24);
            panel1.TabIndex = 130;
            // 
            // PaymentTBAmount
            // 
            PaymentTBAmount.BorderStyle = BorderStyle.None;
            PaymentTBAmount.Location = new Point(4, 4);
            PaymentTBAmount.Name = "PaymentTBAmount";
            PaymentTBAmount.Size = new Size(225, 16);
            PaymentTBAmount.TabIndex = 2;
            PaymentTBAmount.TextChanged += PaymentTBAmount_TextChanged;
            PaymentTBAmount.KeyPress += PaymentTBAmount_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(58, 113);
            label6.Name = "label6";
            label6.Size = new Size(124, 21);
            label6.TabIndex = 140;
            label6.Text = "Metodo de pago";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(PaymentCBPayMethod);
            panel5.Location = new Point(58, 146);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 30);
            panel5.TabIndex = 141;
            // 
            // PaymentCBPayMethod
            // 
            PaymentCBPayMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            PaymentCBPayMethod.FormattingEnabled = true;
            PaymentCBPayMethod.Location = new Point(3, 4);
            PaymentCBPayMethod.Name = "PaymentCBPayMethod";
            PaymentCBPayMethod.Size = new Size(226, 23);
            PaymentCBPayMethod.TabIndex = 0;
            // 
            // AddPaymentScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 577);
            Controls.Add(label6);
            Controls.Add(panel5);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "AddPaymentScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPaymentScreen";
            Load += AddPaymentScreen_Load;
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel UpsertPNLBTN;
        private Label PaymentSaveBTNLBL;
        private PictureBox UpsertPCTBXBTN;
        private Label label4;
        private Panel panel3;
        private TextBox PaymentCBDetail;
        private Label label2;
        private Panel panel1;
        private TextBox PaymentTBAmount;
        private Label label6;
        private Panel panel5;
        private ComboBox PaymentCBPayMethod;
    }
}