namespace Condominium_System.Presentation.Views
{
    partial class PaymentReportScreen
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
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            label6 = new Label();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            panel5 = new Panel();
            PaymentReportTBPropietaryDocument = new TextBox();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.DarkGreen;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(726, 152);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(169, 41);
            CondominiumPNLBTNCreate.TabIndex = 58;
            CondominiumPNLBTNCreate.Click += GeneratePaymentReportBTN_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(39, 12);
            label8.Name = "label8";
            label8.Size = new Size(125, 21);
            label8.TabIndex = 1;
            label8.Text = "Generar Reporte";
            label8.Click += GeneratePaymentReportBTN_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.export_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.Click += GeneratePaymentReportBTN_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(44, 130);
            label6.Name = "label6";
            label6.Size = new Size(197, 21);
            label6.TabIndex = 56;
            label6.Text = "Documento del propietario";
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(pictureBox5);
            panel2.Location = new Point(279, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 29);
            panel2.TabIndex = 75;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.search_white;
            pictureBox5.Location = new Point(0, 2);
            pictureBox5.Margin = new Padding(0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(32, 23);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            pictureBox5.Click += SearchPropietaryBTN_Click;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(PaymentReportTBPropietaryDocument);
            panel5.Location = new Point(44, 155);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 30);
            panel5.TabIndex = 74;
            // 
            // PaymentReportTBPropietaryDocument
            // 
            PaymentReportTBPropietaryDocument.Location = new Point(3, 3);
            PaymentReportTBPropietaryDocument.Name = "PaymentReportTBPropietaryDocument";
            PaymentReportTBPropietaryDocument.Size = new Size(226, 23);
            PaymentReportTBPropietaryDocument.TabIndex = 0;
            // 
            // PaymentReportScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 592);
            Controls.Add(panel2);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(panel5);
            Controls.Add(label6);
            Name = "PaymentReportScreen";
            Text = "PaymentReport";
            Load += PaymentReportScreen_Load;
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private Label label6;
        private Panel panel2;
        private PictureBox pictureBox5;
        private Panel panel5;
        private TextBox PaymentReportTBPropietaryDocument;
    }
}