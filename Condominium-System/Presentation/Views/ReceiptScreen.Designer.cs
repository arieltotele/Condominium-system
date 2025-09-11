namespace Condominium_System.Presentation.Views
{
    partial class ReceiptScreen
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
            label6 = new Label();
            panel5 = new Panel();
            ReceiptCBCondominium = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            ReceiptCBYear = new ComboBox();
            GenerateReceiptsPanel = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            toolTip1 = new ToolTip(components);
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            GenerateReceiptsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 103);
            label6.Name = "label6";
            label6.Size = new Size(96, 21);
            label6.TabIndex = 61;
            label6.Text = "Condominio";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(ReceiptCBCondominium);
            panel5.Location = new Point(12, 136);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 30);
            panel5.TabIndex = 62;
            toolTip1.SetToolTip(panel5, "Seleccione un condominio.");
            // 
            // ReceiptCBCondominium
            // 
            ReceiptCBCondominium.DropDownStyle = ComboBoxStyle.DropDownList;
            ReceiptCBCondominium.FormattingEnabled = true;
            ReceiptCBCondominium.Location = new Point(3, 4);
            ReceiptCBCondominium.Name = "ReceiptCBCondominium";
            ReceiptCBCondominium.Size = new Size(226, 23);
            ReceiptCBCondominium.TabIndex = 0;
            toolTip1.SetToolTip(ReceiptCBCondominium, "Seleccione un condominio.");
            ReceiptCBCondominium.SelectedIndexChanged += ReceiptCBCondominium_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(587, 103);
            label1.Name = "label1";
            label1.Size = new Size(38, 21);
            label1.TabIndex = 63;
            label1.Text = "Año";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(ReceiptCBYear);
            panel1.Location = new Point(587, 136);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 30);
            panel1.TabIndex = 64;
            // 
            // ReceiptCBYear
            // 
            ReceiptCBYear.FormattingEnabled = true;
            ReceiptCBYear.Location = new Point(3, 3);
            ReceiptCBYear.Name = "ReceiptCBYear";
            ReceiptCBYear.Size = new Size(226, 23);
            ReceiptCBYear.TabIndex = 0;
            toolTip1.SetToolTip(ReceiptCBYear, "Seleccione un año.");
            // 
            // GenerateReceiptsPanel
            // 
            GenerateReceiptsPanel.BackColor = Color.DarkGreen;
            GenerateReceiptsPanel.Controls.Add(label2);
            GenerateReceiptsPanel.Controls.Add(pictureBox1);
            GenerateReceiptsPanel.ForeColor = SystemColors.ControlText;
            GenerateReceiptsPanel.Location = new Point(354, 232);
            GenerateReceiptsPanel.Name = "GenerateReceiptsPanel";
            GenerateReceiptsPanel.Size = new Size(169, 41);
            GenerateReceiptsPanel.TabIndex = 65;
            toolTip1.SetToolTip(GenerateReceiptsPanel, "Generar recibos para las viviendas.");
            GenerateReceiptsPanel.Click += GenerateReceiptsBTN_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(39, 12);
            label2.Name = "label2";
            label2.Size = new Size(120, 21);
            label2.TabIndex = 1;
            label2.Text = "Generar recibos";
            toolTip1.SetToolTip(label2, "Generar recibos para las viviendas.");
            label2.Click += GenerateReceiptsBTN_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.export_white;
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Generar recibos para las viviendas.");
            pictureBox1.Click += GenerateReceiptsBTN_Click;
            // 
            // ReceiptScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(GenerateReceiptsPanel);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(panel5);
            Name = "ReceiptScreen";
            Text = "ReceiptScreen";
            Load += ReceiptScreen_Load;
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            GenerateReceiptsPanel.ResumeLayout(false);
            GenerateReceiptsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Panel panel5;
        private ComboBox ReceiptCBCondominium;
        private Label label1;
        private Panel panel1;
        private ComboBox ReceiptCBYear;
        private Panel GenerateReceiptsPanel;
        private Label label2;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
    }
}