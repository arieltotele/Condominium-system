namespace Condominium_System.Presentation.Views
{
    partial class AddServiceScreen
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
            AddServiceLBLTitle = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            SignUpPNLBTNClean = new Panel();
            label12 = new Label();
            pictureBox3 = new PictureBox();
            AddServiceFlowLayoutEssentials = new FlowLayoutPanel();
            AddServiceFlowLayoutCommunity = new FlowLayoutPanel();
            AddServiceFlowLayoutConvivence = new FlowLayoutPanel();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SignUpPNLBTNClean.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(217, 217, 217);
            panel1.Controls.Add(AddServiceLBLTitle);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(782, 64);
            panel1.TabIndex = 0;
            // 
            // AddServiceLBLTitle
            // 
            AddServiceLBLTitle.AutoSize = true;
            AddServiceLBLTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddServiceLBLTitle.Location = new Point(11, 16);
            AddServiceLBLTitle.Name = "AddServiceLBLTitle";
            AddServiceLBLTitle.Size = new Size(348, 32);
            AddServiceLBLTitle.TabIndex = 1;
            AddServiceLBLTitle.Text = "Añadir servicios a la vivienda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 14;
            label2.Text = "Esenciales:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(246, 79);
            label1.Name = "label1";
            label1.Size = new Size(125, 25);
            label1.TabIndex = 18;
            label1.Text = "Comunitarios";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(509, 79);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 22;
            label3.Text = "Convivencia";
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(473, 439);
            panel2.Name = "panel2";
            panel2.Size = new Size(109, 41);
            panel2.TabIndex = 34;
            toolTip1.SetToolTip(panel2, "Finalizar proceso.");
            panel2.Click += AddServicePNLBTNNext_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 12);
            label6.Name = "label6";
            label6.Size = new Size(68, 21);
            label6.TabIndex = 1;
            label6.Text = "Finalizar";
            toolTip1.SetToolTip(label6, "Finalizar proceso.");
            label6.Click += AddServicePNLBTNNext_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.finished_white;
            pictureBox1.Location = new Point(73, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "Finalizar proceso.");
            pictureBox1.Click += AddServicePNLBTNNext_Click;
            // 
            // SignUpPNLBTNClean
            // 
            SignUpPNLBTNClean.BackColor = Color.MidnightBlue;
            SignUpPNLBTNClean.Controls.Add(label12);
            SignUpPNLBTNClean.Controls.Add(pictureBox3);
            SignUpPNLBTNClean.Location = new Point(188, 439);
            SignUpPNLBTNClean.Name = "SignUpPNLBTNClean";
            SignUpPNLBTNClean.Size = new Size(109, 41);
            SignUpPNLBTNClean.TabIndex = 33;
            toolTip1.SetToolTip(SignUpPNLBTNClean, "Limpiar formulario.");
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(39, 12);
            label12.Name = "label12";
            label12.Size = new Size(63, 21);
            label12.TabIndex = 1;
            label12.Text = "Limpiar";
            toolTip1.SetToolTip(label12, "Limpiar formulario.");
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.clean_white;
            pictureBox3.Location = new Point(3, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 19);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "Limpiar formulario.");
            // 
            // AddServiceFlowLayoutEssentials
            // 
            AddServiceFlowLayoutEssentials.Location = new Point(12, 107);
            AddServiceFlowLayoutEssentials.Name = "AddServiceFlowLayoutEssentials";
            AddServiceFlowLayoutEssentials.Size = new Size(209, 285);
            AddServiceFlowLayoutEssentials.TabIndex = 0;
            // 
            // AddServiceFlowLayoutCommunity
            // 
            AddServiceFlowLayoutCommunity.Location = new Point(246, 107);
            AddServiceFlowLayoutCommunity.Name = "AddServiceFlowLayoutCommunity";
            AddServiceFlowLayoutCommunity.Size = new Size(242, 285);
            AddServiceFlowLayoutCommunity.TabIndex = 1;
            // 
            // AddServiceFlowLayoutConvivence
            // 
            AddServiceFlowLayoutConvivence.Location = new Point(509, 107);
            AddServiceFlowLayoutConvivence.Name = "AddServiceFlowLayoutConvivence";
            AddServiceFlowLayoutConvivence.Size = new Size(260, 285);
            AddServiceFlowLayoutConvivence.TabIndex = 2;
            // 
            // AddServiceScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 503);
            Controls.Add(panel2);
            Controls.Add(SignUpPNLBTNClean);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(AddServiceFlowLayoutEssentials);
            Controls.Add(AddServiceFlowLayoutCommunity);
            Controls.Add(AddServiceFlowLayoutConvivence);
            Name = "AddServiceScreen";
            Text = "AddServiceScreen";
            toolTip1.SetToolTip(this, "Finalizar proceso.");
            Load += AddServiceScreen_Load;
            Click += AddServicePNLBTNNext_Click;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SignUpPNLBTNClean.ResumeLayout(false);
            SignUpPNLBTNClean.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label AddServiceLBLTitle;
        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panel2;
        private Label label6;
        private PictureBox pictureBox1;
        private Panel SignUpPNLBTNClean;
        private Label label12;
        private PictureBox pictureBox3;
        private FlowLayoutPanel AddServiceFlowLayoutEssentials;
        private FlowLayoutPanel AddServiceFlowLayoutCommunity;
        private FlowLayoutPanel AddServiceFlowLayoutConvivence;
        private ToolTip toolTip1;
    }
}