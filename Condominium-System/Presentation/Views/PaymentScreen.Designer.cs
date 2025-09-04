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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            PaymentCBHouse = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            PaymentTBPropietaryDocument = new TextBox();
            CondominiumPNLBTNCreate = new Panel();
            SearchPendingReceiptsBTNLBL = new Label();
            SearchPendingReceiptsBTNPCTB = new PictureBox();
            PaymentDTGData = new DataGridView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            toolTip1 = new ToolTip(components);
            btnPagarSeleccionados = new Button();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SearchPendingReceiptsBTNPCTB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaymentDTGData).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(PaymentCBHouse);
            panel1.Location = new Point(393, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(232, 30);
            panel1.TabIndex = 69;
            toolTip1.SetToolTip(panel1, "Seleccione una casa perteneciente al propietario.");
            // 
            // PaymentCBHouse
            // 
            PaymentCBHouse.DropDownStyle = ComboBoxStyle.DropDownList;
            PaymentCBHouse.FormattingEnabled = true;
            PaymentCBHouse.Location = new Point(3, 3);
            PaymentCBHouse.Name = "PaymentCBHouse";
            PaymentCBHouse.Size = new Size(226, 23);
            PaymentCBHouse.TabIndex = 0;
            toolTip1.SetToolTip(PaymentCBHouse, "Seleccione una casa perteneciente al propietario.");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(393, 21);
            label1.Name = "label1";
            label1.Size = new Size(43, 21);
            label1.TabIndex = 68;
            label1.Text = "Casa";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 21);
            label6.Name = "label6";
            label6.Size = new Size(87, 21);
            label6.TabIndex = 66;
            label6.Text = "Propietario";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(PaymentTBPropietaryDocument);
            panel5.Location = new Point(12, 54);
            panel5.Name = "panel5";
            panel5.Size = new Size(232, 30);
            panel5.TabIndex = 67;
            toolTip1.SetToolTip(panel5, "Ingrese el documento del propietario.");
            // 
            // PaymentTBPropietaryDocument
            // 
            PaymentTBPropietaryDocument.Location = new Point(3, 3);
            PaymentTBPropietaryDocument.Name = "PaymentTBPropietaryDocument";
            PaymentTBPropietaryDocument.Size = new Size(226, 23);
            PaymentTBPropietaryDocument.TabIndex = 0;
            toolTip1.SetToolTip(PaymentTBPropietaryDocument, "Ingrese el documento del propietario.");
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(SearchPendingReceiptsBTNLBL);
            CondominiumPNLBTNCreate.Controls.Add(SearchPendingReceiptsBTNPCTB);
            CondominiumPNLBTNCreate.Location = new Point(773, 43);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(155, 41);
            CondominiumPNLBTNCreate.TabIndex = 41;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Buscar los recibos pendientes.");
            CondominiumPNLBTNCreate.Click += SearchPendingReceiptsBTN_Click;
            // 
            // SearchPendingReceiptsBTNLBL
            // 
            SearchPendingReceiptsBTNLBL.AutoSize = true;
            SearchPendingReceiptsBTNLBL.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchPendingReceiptsBTNLBL.ForeColor = Color.White;
            SearchPendingReceiptsBTNLBL.Location = new Point(39, 12);
            SearchPendingReceiptsBTNLBL.Name = "SearchPendingReceiptsBTNLBL";
            SearchPendingReceiptsBTNLBL.Size = new Size(107, 21);
            SearchPendingReceiptsBTNLBL.TabIndex = 1;
            SearchPendingReceiptsBTNLBL.Text = "Buscar Recibo";
            toolTip1.SetToolTip(SearchPendingReceiptsBTNLBL, "Buscar los recibos pendientes.");
            SearchPendingReceiptsBTNLBL.Click += SearchPendingReceiptsBTN_Click;
            // 
            // SearchPendingReceiptsBTNPCTB
            // 
            SearchPendingReceiptsBTNPCTB.Image = Properties.Resources.search_white;
            SearchPendingReceiptsBTNPCTB.Location = new Point(3, 12);
            SearchPendingReceiptsBTNPCTB.Name = "SearchPendingReceiptsBTNPCTB";
            SearchPendingReceiptsBTNPCTB.Size = new Size(30, 19);
            SearchPendingReceiptsBTNPCTB.SizeMode = PictureBoxSizeMode.Zoom;
            SearchPendingReceiptsBTNPCTB.TabIndex = 0;
            SearchPendingReceiptsBTNPCTB.TabStop = false;
            toolTip1.SetToolTip(SearchPendingReceiptsBTNPCTB, "Buscar los recibos pendientes.");
            SearchPendingReceiptsBTNPCTB.Click += SearchPendingReceiptsBTN_Click;
            // 
            // PaymentDTGData
            // 
            PaymentDTGData.AllowUserToResizeColumns = false;
            PaymentDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PaymentDTGData.Dock = DockStyle.Bottom;
            PaymentDTGData.Location = new Point(0, 201);
            PaymentDTGData.Name = "PaymentDTGData";
            PaymentDTGData.ReadOnly = true;
            PaymentDTGData.Size = new Size(1017, 390);
            PaymentDTGData.TabIndex = 70;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1, toolStripStatusLabel2 });
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
            toolStripStatusLabel1.Size = new Size(782, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(pictureBox5);
            panel2.Location = new Point(247, 55);
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
            toolTip1.SetToolTip(pictureBox5, "Buscar las viviendas del propietario.");
            pictureBox5.Click += SearchByDocumentBTN_Click;
            // 
            // btnPagarSeleccionados
            // 
            btnPagarSeleccionados.Location = new Point(899, 138);
            btnPagarSeleccionados.Name = "btnPagarSeleccionados";
            btnPagarSeleccionados.Size = new Size(75, 23);
            btnPagarSeleccionados.TabIndex = 74;
            btnPagarSeleccionados.Text = "PAGAR";
            btnPagarSeleccionados.UseVisualStyleBackColor = true;
            btnPagarSeleccionados.Click += BtnPagarSeleccionados_Click;
            // 
            // PaymentScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(btnPagarSeleccionados);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(PaymentDTGData);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(panel5);
            Name = "PaymentScreen";
            Text = "PaymentScreen";
            toolTip1.SetToolTip(this, "Buscar los recibos pendientes.");
            Load += PaymentScreen_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SearchPendingReceiptsBTNPCTB).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaymentDTGData).EndInit();
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
        private Label SearchPendingReceiptsBTNLBL;
        private PictureBox SearchPendingReceiptsBTNPCTB;
        private DataGridView PaymentDTGData;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel panel2;
        private PictureBox pictureBox5;
        private ToolTip toolTip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button btnPagarSeleccionados;
    }
}