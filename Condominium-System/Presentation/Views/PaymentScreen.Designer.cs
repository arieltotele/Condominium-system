namespace Condominium_System.Presentation.Views
{
    partial class PaymentScreen
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
            panel1 = new Panel();
            PaymentCBHouse = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            PaymentTBPropietaryDocument = new TextBox();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            dataGridView1 = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(PaymentCBHouse);
            panel1.Location = new Point(393, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 30);
            panel1.TabIndex = 69;
            // 
            // PaymentCBHouse
            // 
            PaymentCBHouse.DropDownStyle = ComboBoxStyle.DropDownList;
            PaymentCBHouse.FormattingEnabled = true;
            PaymentCBHouse.Location = new Point(3, 3);
            PaymentCBHouse.Name = "PaymentCBHouse";
            PaymentCBHouse.Size = new Size(226, 23);
            PaymentCBHouse.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(393, 49);
            label1.Name = "label1";
            label1.Size = new Size(43, 21);
            label1.TabIndex = 68;
            label1.Text = "Casa";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 49);
            label6.Name = "label6";
            label6.Size = new Size(87, 21);
            label6.TabIndex = 66;
            label6.Text = "Propietario";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(PaymentTBPropietaryDocument);
            panel5.Location = new Point(12, 82);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 30);
            panel5.TabIndex = 67;
            // 
            // PaymentTBPropietaryDocument
            // 
            PaymentTBPropietaryDocument.Location = new Point(3, 3);
            PaymentTBPropietaryDocument.Name = "PaymentTBPropietaryDocument";
            PaymentTBPropietaryDocument.Size = new Size(226, 23);
            PaymentTBPropietaryDocument.TabIndex = 0;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(773, 71);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(152, 41);
            CondominiumPNLBTNCreate.TabIndex = 41;
            CondominiumPNLBTNCreate.Click += SearchPendingReceiptsBTN_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(39, 12);
            label8.Name = "label8";
            label8.Size = new Size(107, 21);
            label8.TabIndex = 1;
            label8.Text = "Buscar Recibo";
            label8.Click += SearchPendingReceiptsBTN_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.search_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            pictureBox3.Click += SearchPendingReceiptsBTN_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1017, 390);
            dataGridView1.TabIndex = 70;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 179);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1017, 22);
            statusStrip1.TabIndex = 71;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = Color.FromArgb(238, 210, 2);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1002, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(pictureBox5);
            panel2.Location = new Point(247, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(32, 29);
            panel2.TabIndex = 73;
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
            pictureBox5.Click += SearchByDocumentBTN_Click;
            // 
            // PaymentScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(panel5);
            Name = "PaymentScreen";
            Text = "PaymentScreen";
            Load += PaymentScreen_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private ComboBox PaymentCBHouse;
        private Label label1;
        private Label label6;
        private Panel panel5;
        private TextBox PaymentTBPropietaryDocument;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel panel2;
        private PictureBox pictureBox5;
    }
}