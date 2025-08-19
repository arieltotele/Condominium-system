namespace Condominium_System.Presentation.Views
{
    partial class CondominiumScreen
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
            CondominiumDTGData = new DataGridView();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            toolTip1 = new ToolTip(components);
            pictureBox5 = new PictureBox();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label1 = new Label();
            BlockPNLID = new Panel();
            CondominiumTIId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)CondominiumDTGData).BeginInit();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            BlockPNLID.SuspendLayout();
            SuspendLayout();
            // 
            // CondominiumDTGData
            // 
            CondominiumDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CondominiumDTGData.Dock = DockStyle.Bottom;
            CondominiumDTGData.Location = new Point(0, 148);
            CondominiumDTGData.Margin = new Padding(0);
            CondominiumDTGData.Name = "CondominiumDTGData";
            CondominiumDTGData.Size = new Size(1017, 443);
            CondominiumDTGData.TabIndex = 19;
            toolTip1.SetToolTip(CondominiumDTGData, "Condominios almacenados en la Base de Datos.");
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(872, 82);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 35;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear un nuevo condominio.");
            CondominiumPNLBTNCreate.Click += CondominiumBTNCreate_Click;
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
            toolTip1.SetToolTip(label8, "Crear un nuevo condominio.");
            label8.Click += CondominiumBTNCreate_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Crear un nuevo condominio.");
            pictureBox3.Click += CondominiumBTNCreate_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.search_white;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Margin = new Padding(0, 0, 0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            toolTip1.SetToolTip(pictureBox5, "Buscar condominio.");
            // 
            // statusStrip1
            // 
            statusStrip1.GripMargin = new Padding(0);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 126);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1017, 22);
            statusStrip1.TabIndex = 37;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = false;
            statusLabel.ForeColor = Color.FromArgb(238, 210, 2);
            statusLabel.Margin = new Padding(0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1002, 22);
            statusLabel.Spring = true;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel2
            // 
            panel2.BackColor = Color.Red;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(665, 82);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 41);
            panel2.TabIndex = 56;
            panel2.Click += GenerateReportFromFilteredData_Click;
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
            label2.Click += GenerateReportFromFilteredData_Click;
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
            pictureBox1.Click += GenerateReportFromFilteredData_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox5);
            panel1.Location = new Point(244, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(26, 24);
            panel1.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 62);
            label1.Margin = new Padding(0, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 57;
            label1.Text = "ID";
            // 
            // BlockPNLID
            // 
            BlockPNLID.BackColor = SystemColors.Window;
            BlockPNLID.Controls.Add(CondominiumTIId);
            BlockPNLID.Location = new Point(12, 95);
            BlockPNLID.Name = "BlockPNLID";
            BlockPNLID.Size = new Size(236, 24);
            BlockPNLID.TabIndex = 58;
            // 
            // CondominiumTIId
            // 
            CondominiumTIId.BorderStyle = BorderStyle.None;
            CondominiumTIId.Location = new Point(4, 3);
            CondominiumTIId.Margin = new Padding(0, 0, 0, 0);
            CondominiumTIId.Name = "CondominiumTIId";
            CondominiumTIId.Size = new Size(225, 16);
            CondominiumTIId.TabIndex = 2;
            CondominiumTIId.TextChanged += CondominiumTIId_TextChanged;
            // 
            // CondominiumScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(BlockPNLID);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(CondominiumDTGData);
            Name = "CondominiumScreen";
            Text = "CondominuiumScreen";
            Load += CondominuiumScreen_Load;
            ((System.ComponentModel.ISupportInitialize)CondominiumDTGData).EndInit();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            BlockPNLID.ResumeLayout(false);
            BlockPNLID.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView CondominiumDTGData;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private ToolTip toolTip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox5;
        private Label label1;
        private Panel BlockPNLID;
        private TextBox CondominiumTIId;
    }
}