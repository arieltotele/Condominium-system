namespace Condominium_System.Presentation.Views
{
    partial class TenantScreen
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
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            TenantDTGData = new DataGridView();
            BlockPNLID = new Panel();
            TenantTBID = new TextBox();
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TenantDTGData).BeginInit();
            BlockPNLID.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(856, 75);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 45;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear un nuevo inquilino.");
            CondominiumPNLBTNCreate.Click += TenantPNLBTNCreate_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(39, 12);
            label8.Name = "label8";
            label8.Size = new Size(56, 21);
            label8.TabIndex = 1;
            label8.Text = "Nuevo";
            toolTip1.SetToolTip(label8, "Crear un nuevo inquilino.");
            label8.Click += TenantPNLBTNCreate_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.create_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "Crear un nuevo inquilino.");
            pictureBox3.Click += TenantPNLBTNCreate_Click;
            // 
            // TenantDTGData
            // 
            TenantDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TenantDTGData.Dock = DockStyle.Bottom;
            TenantDTGData.Location = new Point(0, 148);
            TenantDTGData.Name = "TenantDTGData";
            TenantDTGData.Size = new Size(1017, 443);
            TenantDTGData.TabIndex = 44;
            // 
            // BlockPNLID
            // 
            BlockPNLID.BackColor = SystemColors.Window;
            BlockPNLID.Controls.Add(TenantTBID);
            BlockPNLID.Location = new Point(12, 92);
            BlockPNLID.Name = "BlockPNLID";
            BlockPNLID.Size = new Size(236, 24);
            BlockPNLID.TabIndex = 43;
            toolTip1.SetToolTip(BlockPNLID, "Buscar inquilinos basado en criterios.");
            // 
            // TenantTBID
            // 
            TenantTBID.BorderStyle = BorderStyle.None;
            TenantTBID.Location = new Point(4, 3);
            TenantTBID.Name = "TenantTBID";
            TenantTBID.Size = new Size(229, 16);
            TenantTBID.TabIndex = 2;
            toolTip1.SetToolTip(TenantTBID, "Buscar inquilinos basado en criterios.");
            TenantTBID.TextChanged += TenantTBID_TextChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 126);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1017, 22);
            statusStrip1.TabIndex = 47;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = false;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1002, 17);
            statusLabel.Spring = true;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGreen;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(665, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 41);
            panel2.TabIndex = 57;
            toolTip1.SetToolTip(panel2, "Generar reporte de inquilinos.");
            panel2.Click += GenerateTenantReportFromFilteredData_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(39, 12);
            label2.Name = "label2";
            label2.Size = new Size(125, 21);
            label2.TabIndex = 1;
            label2.Text = "Generar Reporte";
            toolTip1.SetToolTip(label2, "Generar reporte de inquilinos.");
            label2.Click += GenerateTenantReportFromFilteredData_Click;
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
            toolTip1.SetToolTip(pictureBox1, "Generar reporte de inquilinos.");
            pictureBox1.Click += GenerateTenantReportFromFilteredData_Click;
            // 
            // TenantScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(TenantDTGData);
            Controls.Add(BlockPNLID);
            Name = "TenantScreen";
            Text = "TenantScreen";
            toolTip1.SetToolTip(this, "Generar reporte de inquilinos.");
            Load += TenantScreen_Load;
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)TenantDTGData).EndInit();
            BlockPNLID.ResumeLayout(false);
            BlockPNLID.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private DataGridView TenantDTGData;
        private Panel BlockPNLID;
        private TextBox TenantTBID;
        private ToolTip toolTip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
    }
}