namespace Condominium_System.Presentation.Views
{
    partial class HousingScreen
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
            pictureBox5 = new PictureBox();
            CondominiumPNLBTNCreate = new Panel();
            label8 = new Label();
            pictureBox3 = new PictureBox();
            HousingDTGData = new DataGridView();
            label1 = new Label();
            BlockPNLID = new Panel();
            HousingTBID = new TextBox();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            CondominiumPNLBTNCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HousingDTGData).BeginInit();
            BlockPNLID.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox5);
            panel1.Location = new Point(247, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(26, 24);
            panel1.TabIndex = 46;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.search_white;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            toolTip1.SetToolTip(pictureBox5, "Buscar vivienda.");
            pictureBox5.Click += HousingPNLBTNSearch_Click;
            // 
            // CondominiumPNLBTNCreate
            // 
            CondominiumPNLBTNCreate.BackColor = Color.MidnightBlue;
            CondominiumPNLBTNCreate.Controls.Add(label8);
            CondominiumPNLBTNCreate.Controls.Add(pictureBox3);
            CondominiumPNLBTNCreate.Location = new Point(859, 49);
            CondominiumPNLBTNCreate.Name = "CondominiumPNLBTNCreate";
            CondominiumPNLBTNCreate.Size = new Size(109, 41);
            CondominiumPNLBTNCreate.TabIndex = 45;
            toolTip1.SetToolTip(CondominiumPNLBTNCreate, "Crear casa.");
            CondominiumPNLBTNCreate.Click += HousingPNLBTNCreate_Click;
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
            toolTip1.SetToolTip(label8, "Crear casa.");
            label8.Click += HousingPNLBTNCreate_Click;
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
            toolTip1.SetToolTip(pictureBox3, "Crear casa.");
            pictureBox3.Click += HousingPNLBTNCreate_Click;
            // 
            // HousingDTGData
            // 
            HousingDTGData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HousingDTGData.Dock = DockStyle.Bottom;
            HousingDTGData.Location = new Point(0, 148);
            HousingDTGData.Name = "HousingDTGData";
            HousingDTGData.Size = new Size(1017, 443);
            HousingDTGData.TabIndex = 44;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(15, 33);
            label1.Name = "label1";
            label1.Size = new Size(25, 21);
            label1.TabIndex = 42;
            label1.Text = "ID";
            // 
            // BlockPNLID
            // 
            BlockPNLID.BackColor = SystemColors.Window;
            BlockPNLID.Controls.Add(HousingTBID);
            BlockPNLID.Location = new Point(15, 66);
            BlockPNLID.Name = "BlockPNLID";
            BlockPNLID.Size = new Size(235, 24);
            BlockPNLID.TabIndex = 43;
            // 
            // HousingTBID
            // 
            HousingTBID.BorderStyle = BorderStyle.None;
            HousingTBID.Location = new Point(4, 3);
            HousingTBID.Name = "HousingTBID";
            HousingTBID.Size = new Size(225, 16);
            HousingTBID.TabIndex = 2;
            // 
            // HousingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 591);
            Controls.Add(panel1);
            Controls.Add(CondominiumPNLBTNCreate);
            Controls.Add(HousingDTGData);
            Controls.Add(label1);
            Controls.Add(BlockPNLID);
            Name = "HousingScreen";
            Text = "HousingScreen";
            Load += HousingScreen_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            CondominiumPNLBTNCreate.ResumeLayout(false);
            CondominiumPNLBTNCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)HousingDTGData).EndInit();
            BlockPNLID.ResumeLayout(false);
            BlockPNLID.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox5;
        private Panel CondominiumPNLBTNCreate;
        private Label label8;
        private PictureBox pictureBox3;
        private DataGridView HousingDTGData;
        private Label label1;
        private Panel BlockPNLID;
        private TextBox HousingTBID;
        private ToolTip toolTip1;
    }
}