namespace Condominium_System.Presentation.Views
{
    partial class UpsertIncidenceScreen
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
            label5 = new Label();
            panel5 = new Panel();
            IncidenceDTPDate = new DateTimePicker();
            label6 = new Label();
            panel6 = new Panel();
            IncidenceCBTenants = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            IncidenceTBDescription = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(63, 9);
            label5.Name = "label5";
            label5.Size = new Size(50, 21);
            label5.TabIndex = 101;
            label5.Text = "Fecha";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(IncidenceDTPDate);
            panel5.Location = new Point(63, 42);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 29);
            panel5.TabIndex = 102;
            // 
            // IncidenceDTPDate
            // 
            IncidenceDTPDate.Location = new Point(3, 3);
            IncidenceDTPDate.Name = "IncidenceDTPDate";
            IncidenceDTPDate.Size = new Size(281, 23);
            IncidenceDTPDate.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(63, 112);
            label6.Name = "label6";
            label6.Size = new Size(192, 21);
            label6.TabIndex = 103;
            label6.Text = "Identificación del inquilino";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(IncidenceCBTenants);
            panel6.Location = new Point(63, 145);
            panel6.Name = "panel6";
            panel6.Size = new Size(285, 33);
            panel6.TabIndex = 104;
            // 
            // IncidenceCBTenants
            // 
            IncidenceCBTenants.DropDownStyle = ComboBoxStyle.DropDownList;
            IncidenceCBTenants.FormattingEnabled = true;
            IncidenceCBTenants.Location = new Point(3, 6);
            IncidenceCBTenants.Name = "IncidenceCBTenants";
            IncidenceCBTenants.Size = new Size(279, 23);
            IncidenceCBTenants.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(63, 209);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 105;
            label2.Text = "Descripción";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(IncidenceTBDescription);
            panel1.Location = new Point(63, 242);
            panel1.Name = "panel1";
            panel1.Size = new Size(294, 68);
            panel1.TabIndex = 106;
            // 
            // IncidenceTBDescription
            // 
            IncidenceTBDescription.BorderStyle = BorderStyle.None;
            IncidenceTBDescription.Location = new Point(4, 4);
            IncidenceTBDescription.Multiline = true;
            IncidenceTBDescription.Name = "IncidenceTBDescription";
            IncidenceTBDescription.Size = new Size(287, 61);
            IncidenceTBDescription.TabIndex = 2;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(146, 354);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 107;
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
            // UpsertIncidenceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 427);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label5);
            Controls.Add(panel5);
            Controls.Add(label6);
            Controls.Add(panel6);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "UpsertIncidenceScreen";
            Text = "UpsertIncidenceScreen";
            Load += UpsertIncidenceScreen_Load;
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Panel panel5;
        private DateTimePicker IncidenceDTPDate;
        private Label label6;
        private Panel panel6;
        private ComboBox IncidenceCBTenants;
        private Label label2;
        private Panel panel1;
        private TextBox IncidenceTBDescription;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
    }
}