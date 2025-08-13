namespace Condominium_System.Presentation.Views
{
    partial class ReportScreen
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
            ReportComboBxEntities = new ComboBox();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            panel5.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 137);
            label6.Name = "label6";
            label6.Size = new Size(308, 21);
            label6.TabIndex = 53;
            label6.Text = "Entidad sobre la que desea hacer el reporte";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(ReportComboBxEntities);
            panel5.Location = new Point(12, 170);
            panel5.Name = "panel5";
            panel5.Size = new Size(394, 30);
            panel5.TabIndex = 54;
            // 
            // ReportComboBxEntities
            // 
            ReportComboBxEntities.DropDownStyle = ComboBoxStyle.DropDownList;
            ReportComboBxEntities.FormattingEnabled = true;
            ReportComboBxEntities.Location = new Point(3, 4);
            ReportComboBxEntities.Name = "ReportComboBxEntities";
            ReportComboBxEntities.Size = new Size(385, 23);
            ReportComboBxEntities.TabIndex = 0;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(694, 159);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(169, 41);
            CondominiumPNLBTNCreate.TabIndex = 55;
            CondominiumPNLBTNCreate.Click += GenerateReportBTN_Click;
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
            label8.Click += GenerateReportBTN_Click;
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
            pictureBox3.Click += GenerateReportBTN_Click;
            // 
            // ReportScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(label6);
            Controls.Add(panel5);
            Name = "ReportScreen";
            Text = "ReportScreen";
            Load += ReportScreen_Load;
            panel5.ResumeLayout(false);
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Panel panel5;
        private ComboBox ReportComboBxEntities;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
    }
}