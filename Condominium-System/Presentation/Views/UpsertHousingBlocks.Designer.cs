namespace Condominium_System.Presentation.Views
{
    partial class UpsertHousingBlocks
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
            label10 = new Label();
            panel4 = new Panel();
            BlockTBFeature = new TextBox();
            BlockCBCondominium = new ComboBox();
            label9 = new Label();
            panel2 = new Panel();
            BlockTBHouseQuantity = new TextBox();
            BlockCBTypeHousing = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            BlockTBAddress = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            BlockTBName = new TextBox();
            UpsertPNLBTN = new Panel();
            UpsertLBLBTN = new Label();
            UpsertPCTBXBTN = new PictureBox();
            toolTip1 = new ToolTip(components);
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            UpsertPNLBTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).BeginInit();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(39, 317);
            label10.Name = "label10";
            label10.Size = new Size(110, 21);
            label10.TabIndex = 68;
            label10.Text = "Caracteristicas";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(BlockTBFeature);
            panel4.Location = new Point(39, 350);
            panel4.Name = "panel4";
            panel4.Size = new Size(334, 51);
            panel4.TabIndex = 69;
            // 
            // BlockTBFeature
            // 
            BlockTBFeature.BorderStyle = BorderStyle.None;
            BlockTBFeature.Location = new Point(4, 4);
            BlockTBFeature.Multiline = true;
            BlockTBFeature.Name = "BlockTBFeature";
            BlockTBFeature.Size = new Size(327, 41);
            BlockTBFeature.TabIndex = 2;
            // 
            // BlockCBCondominium
            // 
            BlockCBCondominium.DropDownStyle = ComboBoxStyle.DropDownList;
            BlockCBCondominium.FormattingEnabled = true;
            BlockCBCondominium.Location = new Point(42, 446);
            BlockCBCondominium.Name = "BlockCBCondominium";
            BlockCBCondominium.Size = new Size(327, 23);
            BlockCBCondominium.TabIndex = 67;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(39, 422);
            label9.Name = "label9";
            label9.Size = new Size(96, 21);
            label9.TabIndex = 66;
            label9.Text = "Condominio";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(BlockTBHouseQuantity);
            panel2.Location = new Point(39, 273);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 28);
            panel2.TabIndex = 65;
            // 
            // BlockTBHouseQuantity
            // 
            BlockTBHouseQuantity.Location = new Point(3, 3);
            BlockTBHouseQuantity.Name = "BlockTBHouseQuantity";
            BlockTBHouseQuantity.Size = new Size(327, 23);
            BlockTBHouseQuantity.TabIndex = 50;
            BlockTBHouseQuantity.Text = " ";
            BlockTBHouseQuantity.KeyPress += BlockTBHouseQuantity_KeyPress;
            // 
            // BlockCBTypeHousing
            // 
            BlockCBTypeHousing.DropDownStyle = ComboBoxStyle.DropDownList;
            BlockCBTypeHousing.FormattingEnabled = true;
            BlockCBTypeHousing.Location = new Point(35, 198);
            BlockCBTypeHousing.Name = "BlockCBTypeHousing";
            BlockCBTypeHousing.Size = new Size(334, 23);
            BlockCBTypeHousing.TabIndex = 64;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(35, 238);
            label5.Name = "label5";
            label5.Size = new Size(162, 21);
            label5.TabIndex = 63;
            label5.Text = "Cantidad de viviendas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(35, 163);
            label3.Name = "label3";
            label3.Size = new Size(123, 21);
            label3.TabIndex = 62;
            label3.Text = "Tipo de vivienda";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(35, 85);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 60;
            label4.Text = "Dirección";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(BlockTBAddress);
            panel3.Location = new Point(35, 118);
            panel3.Name = "panel3";
            panel3.Size = new Size(334, 24);
            panel3.TabIndex = 61;
            // 
            // BlockTBAddress
            // 
            BlockTBAddress.BorderStyle = BorderStyle.None;
            BlockTBAddress.Location = new Point(4, 4);
            BlockTBAddress.Name = "BlockTBAddress";
            BlockTBAddress.Size = new Size(327, 16);
            BlockTBAddress.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(35, 9);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 58;
            label2.Text = "Nombre";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(BlockTBName);
            panel1.Location = new Point(35, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 24);
            panel1.TabIndex = 59;
            // 
            // BlockTBName
            // 
            BlockTBName.BorderStyle = BorderStyle.None;
            BlockTBName.Location = new Point(4, 4);
            BlockTBName.Name = "BlockTBName";
            BlockTBName.Size = new Size(327, 16);
            BlockTBName.TabIndex = 2;
            // 
            // UpsertPNLBTN
            // 
            UpsertPNLBTN.BackColor = Color.MidnightBlue;
            UpsertPNLBTN.Controls.Add(UpsertLBLBTN);
            UpsertPNLBTN.Controls.Add(UpsertPCTBXBTN);
            UpsertPNLBTN.Location = new Point(148, 530);
            UpsertPNLBTN.Name = "UpsertPNLBTN";
            UpsertPNLBTN.Size = new Size(109, 41);
            UpsertPNLBTN.TabIndex = 70;
            toolTip1.SetToolTip(UpsertPNLBTN, "Guardar/Actualizar bloque.");
            UpsertPNLBTN.Click += UpsertLBLBTN_Click;
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
            toolTip1.SetToolTip(UpsertLBLBTN, "Guardar/Actualizar bloque.");
            UpsertLBLBTN.Click += UpsertLBLBTN_Click;
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
            toolTip1.SetToolTip(UpsertPCTBXBTN, "Guardar/Actualizar bloque.");
            UpsertPCTBXBTN.Click += UpsertLBLBTN_Click;
            // 
            // UpsertHousingBlocks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 597);
            Controls.Add(UpsertPNLBTN);
            Controls.Add(label10);
            Controls.Add(panel4);
            Controls.Add(BlockCBCondominium);
            Controls.Add(label9);
            Controls.Add(panel2);
            Controls.Add(BlockCBTypeHousing);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "UpsertHousingBlocks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpsertHousingBlocks";
            Load += UpsertHousingBlocks_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            UpsertPNLBTN.ResumeLayout(false);
            UpsertPNLBTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UpsertPCTBXBTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Panel panel4;
        private TextBox BlockTBFeature;
        private ComboBox BlockCBCondominium;
        private Label label9;
        private Panel panel2;
        private TextBox BlockTBHouseQuantity;
        private ComboBox BlockCBTypeHousing;
        private Label label5;
        private Label label3;
        private Label label4;
        private Panel panel3;
        private TextBox BlockTBAddress;
        private Label label2;
        private Panel panel1;
        private TextBox BlockTBName;
        private Panel UpsertPNLBTN;
        private Label UpsertLBLBTN;
        private PictureBox UpsertPCTBXBTN;
        private ToolTip toolTip1;
    }
}