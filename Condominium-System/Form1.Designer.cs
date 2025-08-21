namespace Condominium_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox5 = new PictureBox();
            BlockPNLID = new Panel();
            CondominiumTIId = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            BlockPNLID.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(pictureBox5);
            panel1.Location = new Point(503, 213);
            panel1.Name = "panel1";
            panel1.Size = new Size(26, 24);
            panel1.TabIndex = 61;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.search_white;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Margin = new Padding(0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(22, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // BlockPNLID
            // 
            BlockPNLID.BackColor = SystemColors.Window;
            BlockPNLID.Controls.Add(CondominiumTIId);
            BlockPNLID.Location = new Point(271, 213);
            BlockPNLID.Name = "BlockPNLID";
            BlockPNLID.Size = new Size(236, 24);
            BlockPNLID.TabIndex = 60;
            // 
            // CondominiumTIId
            // 
            CondominiumTIId.BorderStyle = BorderStyle.None;
            CondominiumTIId.Location = new Point(4, 3);
            CondominiumTIId.Margin = new Padding(0);
            CondominiumTIId.Name = "CondominiumTIId";
            CondominiumTIId.Size = new Size(225, 16);
            CondominiumTIId.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(BlockPNLID);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            BlockPNLID.ResumeLayout(false);
            BlockPNLID.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox5;
        private Panel BlockPNLID;
        private TextBox CondominiumTIId;
    }
}
