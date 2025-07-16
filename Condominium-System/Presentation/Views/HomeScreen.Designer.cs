namespace Condominium_System.Presentation.Views
{
    partial class HomeScreen
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
            HomeScreenBTNLogOut = new PictureBox();
            HomeScreenLBLTitleName = new Label();
            label1 = new Label();
            HomeScreenPNLMenu = new Panel();
            HomeScreenPNLUsers = new Panel();
            HomeScreenLBLUsers = new Label();
            pictureBox10 = new PictureBox();
            HomeScreenPNLMaintenance = new Panel();
            HomeScreenLBLMaintenance = new Label();
            pictureBox9 = new PictureBox();
            HomeScreenPNLFurniture = new Panel();
            HomeScreenLBLFurniture = new Label();
            pictureBox8 = new PictureBox();
            HomeScreenPNLInvoice = new Panel();
            HomeScreenLBLInvoice = new Label();
            pictureBox7 = new PictureBox();
            HomeScreenPNLIncidence = new Panel();
            HomeScreenLBLIncidence = new Label();
            pictureBox6 = new PictureBox();
            HomeScreenPNLTenant = new Panel();
            HomeScreenLBLTenant = new Label();
            pictureBox5 = new PictureBox();
            HomeScreenPNLHousing = new Panel();
            HomeScreenLBLHousing = new Label();
            pictureBox4 = new PictureBox();
            HomeScreenPNLHouseBlocks = new Panel();
            HomeScreenLBLHouseBlocks = new Label();
            pictureBox3 = new PictureBox();
            HomeScreenPNLCondominium = new Panel();
            HomeScreenLBLCondominium = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            HomeScreenLBLTitle = new Label();
            HomeScreenPNLMain = new Panel();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HomeScreenBTNLogOut).BeginInit();
            HomeScreenPNLMenu.SuspendLayout();
            HomeScreenPNLUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            HomeScreenPNLMaintenance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            HomeScreenPNLFurniture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            HomeScreenPNLInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            HomeScreenPNLIncidence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            HomeScreenPNLTenant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            HomeScreenPNLHousing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            HomeScreenPNLHouseBlocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            HomeScreenPNLCondominium.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 65, 194);
            panel1.Controls.Add(HomeScreenBTNLogOut);
            panel1.Controls.Add(HomeScreenLBLTitleName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1202, 70);
            panel1.TabIndex = 0;
            // 
            // HomeScreenBTNLogOut
            // 
            HomeScreenBTNLogOut.Image = Properties.Resources.power_off_white;
            HomeScreenBTNLogOut.Location = new Point(1126, 12);
            HomeScreenBTNLogOut.Name = "HomeScreenBTNLogOut";
            HomeScreenBTNLogOut.Size = new Size(64, 50);
            HomeScreenBTNLogOut.SizeMode = PictureBoxSizeMode.Zoom;
            HomeScreenBTNLogOut.TabIndex = 2;
            HomeScreenBTNLogOut.TabStop = false;
            toolTip1.SetToolTip(HomeScreenBTNLogOut, "Cerrar sesión");
            HomeScreenBTNLogOut.Click += HomeScreenBTNLogOut_Click;
            // 
            // HomeScreenLBLTitleName
            // 
            HomeScreenLBLTitleName.AutoSize = true;
            HomeScreenLBLTitleName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLTitleName.ForeColor = Color.White;
            HomeScreenLBLTitleName.Location = new Point(910, 18);
            HomeScreenLBLTitleName.Name = "HomeScreenLBLTitleName";
            HomeScreenLBLTitleName.Size = new Size(166, 30);
            HomeScreenLBLTitleName.TabIndex = 1;
            HomeScreenLBLTitleName.Text = "Hola, Juan Perez";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(256, 30);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Condominios";
            toolTip1.SetToolTip(label1, "Nombre de la aplicación");
            // 
            // HomeScreenPNLMenu
            // 
            HomeScreenPNLMenu.BackColor = Color.FromArgb(8, 33, 85);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLUsers);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLMaintenance);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLFurniture);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLInvoice);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLIncidence);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLTenant);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLHousing);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLHouseBlocks);
            HomeScreenPNLMenu.Controls.Add(HomeScreenPNLCondominium);
            HomeScreenPNLMenu.Location = new Point(0, 69);
            HomeScreenPNLMenu.Name = "HomeScreenPNLMenu";
            HomeScreenPNLMenu.Size = new Size(170, 690);
            HomeScreenPNLMenu.TabIndex = 1;
            // 
            // HomeScreenPNLUsers
            // 
            HomeScreenPNLUsers.Controls.Add(HomeScreenLBLUsers);
            HomeScreenPNLUsers.Controls.Add(pictureBox10);
            HomeScreenPNLUsers.Location = new Point(3, 605);
            HomeScreenPNLUsers.Name = "HomeScreenPNLUsers";
            HomeScreenPNLUsers.Size = new Size(164, 44);
            HomeScreenPNLUsers.TabIndex = 9;
            toolTip1.SetToolTip(HomeScreenPNLUsers, "Ir al módulo de Usuario");
            // 
            // HomeScreenLBLUsers
            // 
            HomeScreenLBLUsers.AutoSize = true;
            HomeScreenLBLUsers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLUsers.ForeColor = Color.White;
            HomeScreenLBLUsers.Location = new Point(45, 14);
            HomeScreenLBLUsers.Name = "HomeScreenLBLUsers";
            HomeScreenLBLUsers.Size = new Size(71, 21);
            HomeScreenLBLUsers.TabIndex = 1;
            HomeScreenLBLUsers.Text = "Usuarios";
            toolTip1.SetToolTip(HomeScreenLBLUsers, "Ir al módulo de Usuario");
            // 
            // pictureBox10
            // 
            pictureBox10.Image = Properties.Resources.users_white;
            pictureBox10.Location = new Point(9, 10);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(30, 25);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 0;
            pictureBox10.TabStop = false;
            toolTip1.SetToolTip(pictureBox10, "Ir al módulo de Usuario");
            // 
            // HomeScreenPNLMaintenance
            // 
            HomeScreenPNLMaintenance.Controls.Add(HomeScreenLBLMaintenance);
            HomeScreenPNLMaintenance.Controls.Add(pictureBox9);
            HomeScreenPNLMaintenance.Location = new Point(3, 538);
            HomeScreenPNLMaintenance.Name = "HomeScreenPNLMaintenance";
            HomeScreenPNLMaintenance.Size = new Size(164, 44);
            HomeScreenPNLMaintenance.TabIndex = 8;
            toolTip1.SetToolTip(HomeScreenPNLMaintenance, "Ir al módulo de Servicio");
            // 
            // HomeScreenLBLMaintenance
            // 
            HomeScreenLBLMaintenance.AutoSize = true;
            HomeScreenLBLMaintenance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLMaintenance.ForeColor = Color.White;
            HomeScreenLBLMaintenance.Location = new Point(45, 14);
            HomeScreenLBLMaintenance.Name = "HomeScreenLBLMaintenance";
            HomeScreenLBLMaintenance.Size = new Size(72, 21);
            HomeScreenLBLMaintenance.TabIndex = 1;
            HomeScreenLBLMaintenance.Text = "Servicios";
            toolTip1.SetToolTip(HomeScreenLBLMaintenance, "Ir al módulo de Servicio");
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Properties.Resources.maintenance_white;
            pictureBox9.Location = new Point(9, 10);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(30, 25);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 0;
            pictureBox9.TabStop = false;
            toolTip1.SetToolTip(pictureBox9, "Ir al módulo de Servicio");
            // 
            // HomeScreenPNLFurniture
            // 
            HomeScreenPNLFurniture.Controls.Add(HomeScreenLBLFurniture);
            HomeScreenPNLFurniture.Controls.Add(pictureBox8);
            HomeScreenPNLFurniture.Location = new Point(3, 469);
            HomeScreenPNLFurniture.Name = "HomeScreenPNLFurniture";
            HomeScreenPNLFurniture.Size = new Size(164, 44);
            HomeScreenPNLFurniture.TabIndex = 7;
            toolTip1.SetToolTip(HomeScreenPNLFurniture, "Ir al módulo de Mobiliario");
            // 
            // HomeScreenLBLFurniture
            // 
            HomeScreenLBLFurniture.AutoSize = true;
            HomeScreenLBLFurniture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLFurniture.ForeColor = Color.White;
            HomeScreenLBLFurniture.Location = new Point(45, 14);
            HomeScreenLBLFurniture.Name = "HomeScreenLBLFurniture";
            HomeScreenLBLFurniture.Size = new Size(81, 21);
            HomeScreenLBLFurniture.TabIndex = 1;
            HomeScreenLBLFurniture.Text = "Mobiliario";
            toolTip1.SetToolTip(HomeScreenLBLFurniture, "Ir al módulo de Mobiliario");
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.furniture_white;
            pictureBox8.Location = new Point(9, 10);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(30, 25);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 0;
            pictureBox8.TabStop = false;
            toolTip1.SetToolTip(pictureBox8, "Ir al módulo de Mobiliario");
            // 
            // HomeScreenPNLInvoice
            // 
            HomeScreenPNLInvoice.Controls.Add(HomeScreenLBLInvoice);
            HomeScreenPNLInvoice.Controls.Add(pictureBox7);
            HomeScreenPNLInvoice.Location = new Point(3, 401);
            HomeScreenPNLInvoice.Name = "HomeScreenPNLInvoice";
            HomeScreenPNLInvoice.Size = new Size(164, 44);
            HomeScreenPNLInvoice.TabIndex = 6;
            toolTip1.SetToolTip(HomeScreenPNLInvoice, "Ir al módulo de Factura");
            // 
            // HomeScreenLBLInvoice
            // 
            HomeScreenLBLInvoice.AutoSize = true;
            HomeScreenLBLInvoice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLInvoice.ForeColor = Color.White;
            HomeScreenLBLInvoice.Location = new Point(45, 14);
            HomeScreenLBLInvoice.Name = "HomeScreenLBLInvoice";
            HomeScreenLBLInvoice.Size = new Size(60, 21);
            HomeScreenLBLInvoice.TabIndex = 1;
            HomeScreenLBLInvoice.Text = "Factura";
            toolTip1.SetToolTip(HomeScreenLBLInvoice, "Ir al módulo de Factura");
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.invoice_white;
            pictureBox7.Location = new Point(9, 10);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 25);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 0;
            pictureBox7.TabStop = false;
            toolTip1.SetToolTip(pictureBox7, "Ir al módulo de Factura");
            // 
            // HomeScreenPNLIncidence
            // 
            HomeScreenPNLIncidence.Controls.Add(HomeScreenLBLIncidence);
            HomeScreenPNLIncidence.Controls.Add(pictureBox6);
            HomeScreenPNLIncidence.Location = new Point(3, 331);
            HomeScreenPNLIncidence.Name = "HomeScreenPNLIncidence";
            HomeScreenPNLIncidence.Size = new Size(164, 44);
            HomeScreenPNLIncidence.TabIndex = 5;
            toolTip1.SetToolTip(HomeScreenPNLIncidence, "Ir al módulo de Incidencia");
            // 
            // HomeScreenLBLIncidence
            // 
            HomeScreenLBLIncidence.AutoSize = true;
            HomeScreenLBLIncidence.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLIncidence.ForeColor = Color.White;
            HomeScreenLBLIncidence.Location = new Point(45, 14);
            HomeScreenLBLIncidence.Name = "HomeScreenLBLIncidence";
            HomeScreenLBLIncidence.Size = new Size(79, 21);
            HomeScreenLBLIncidence.TabIndex = 1;
            HomeScreenLBLIncidence.Text = "Incidencia";
            toolTip1.SetToolTip(HomeScreenLBLIncidence, "Ir al módulo de Incidencia");
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.incidence_white;
            pictureBox6.Location = new Point(9, 10);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 25);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            toolTip1.SetToolTip(pictureBox6, "Ir al módulo de Incidencia");
            // 
            // HomeScreenPNLTenant
            // 
            HomeScreenPNLTenant.Controls.Add(HomeScreenLBLTenant);
            HomeScreenPNLTenant.Controls.Add(pictureBox5);
            HomeScreenPNLTenant.Location = new Point(3, 263);
            HomeScreenPNLTenant.Name = "HomeScreenPNLTenant";
            HomeScreenPNLTenant.Size = new Size(164, 44);
            HomeScreenPNLTenant.TabIndex = 4;
            toolTip1.SetToolTip(HomeScreenPNLTenant, "Ir al módulo de Inquilino");
            // 
            // HomeScreenLBLTenant
            // 
            HomeScreenLBLTenant.AutoSize = true;
            HomeScreenLBLTenant.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLTenant.ForeColor = Color.White;
            HomeScreenLBLTenant.Location = new Point(45, 14);
            HomeScreenLBLTenant.Name = "HomeScreenLBLTenant";
            HomeScreenLBLTenant.Size = new Size(71, 21);
            HomeScreenLBLTenant.TabIndex = 1;
            HomeScreenLBLTenant.Text = "Inquilino";
            toolTip1.SetToolTip(HomeScreenLBLTenant, "Ir al módulo de Inquilino");
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.tenant_white;
            pictureBox5.Location = new Point(9, 10);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 25);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            toolTip1.SetToolTip(pictureBox5, "Ir al módulo de Inquilino");
            // 
            // HomeScreenPNLHousing
            // 
            HomeScreenPNLHousing.Controls.Add(HomeScreenLBLHousing);
            HomeScreenPNLHousing.Controls.Add(pictureBox4);
            HomeScreenPNLHousing.Location = new Point(3, 196);
            HomeScreenPNLHousing.Name = "HomeScreenPNLHousing";
            HomeScreenPNLHousing.Size = new Size(164, 44);
            HomeScreenPNLHousing.TabIndex = 3;
            toolTip1.SetToolTip(HomeScreenPNLHousing, "Ir al módulo de Vivienda");
            // 
            // HomeScreenLBLHousing
            // 
            HomeScreenLBLHousing.AutoSize = true;
            HomeScreenLBLHousing.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLHousing.ForeColor = Color.White;
            HomeScreenLBLHousing.Location = new Point(45, 14);
            HomeScreenLBLHousing.Name = "HomeScreenLBLHousing";
            HomeScreenLBLHousing.Size = new Size(70, 21);
            HomeScreenLBLHousing.TabIndex = 1;
            HomeScreenLBLHousing.Text = "Vivienda";
            toolTip1.SetToolTip(HomeScreenLBLHousing, "Ir al módulo de Vivienda");
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.house_white;
            pictureBox4.Location = new Point(9, 10);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 25);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            toolTip1.SetToolTip(pictureBox4, "Ir al módulo de Vivienda");
            // 
            // HomeScreenPNLHouseBlocks
            // 
            HomeScreenPNLHouseBlocks.Controls.Add(HomeScreenLBLHouseBlocks);
            HomeScreenPNLHouseBlocks.Controls.Add(pictureBox3);
            HomeScreenPNLHouseBlocks.Location = new Point(3, 126);
            HomeScreenPNLHouseBlocks.Name = "HomeScreenPNLHouseBlocks";
            HomeScreenPNLHouseBlocks.Size = new Size(164, 44);
            HomeScreenPNLHouseBlocks.TabIndex = 2;
            toolTip1.SetToolTip(HomeScreenPNLHouseBlocks, "Ir al módulo de Bloque");
            // 
            // HomeScreenLBLHouseBlocks
            // 
            HomeScreenLBLHouseBlocks.AutoSize = true;
            HomeScreenLBLHouseBlocks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLHouseBlocks.ForeColor = Color.White;
            HomeScreenLBLHouseBlocks.Location = new Point(45, 14);
            HomeScreenLBLHouseBlocks.Name = "HomeScreenLBLHouseBlocks";
            HomeScreenLBLHouseBlocks.Size = new Size(58, 21);
            HomeScreenLBLHouseBlocks.TabIndex = 1;
            HomeScreenLBLHouseBlocks.Text = "Bloque";
            toolTip1.SetToolTip(HomeScreenLBLHouseBlocks, "Ir al módulo de Bloque");
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.blocks_white;
            pictureBox3.Location = new Point(9, 10);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 25);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            toolTip1.SetToolTip(pictureBox3, "Ir al módulo de Bloque");
            // 
            // HomeScreenPNLCondominium
            // 
            HomeScreenPNLCondominium.Controls.Add(HomeScreenLBLCondominium);
            HomeScreenPNLCondominium.Controls.Add(pictureBox2);
            HomeScreenPNLCondominium.Location = new Point(3, 59);
            HomeScreenPNLCondominium.Name = "HomeScreenPNLCondominium";
            HomeScreenPNLCondominium.Size = new Size(164, 44);
            HomeScreenPNLCondominium.TabIndex = 0;
            toolTip1.SetToolTip(HomeScreenPNLCondominium, "Ir al módulo de Condominio");
            // 
            // HomeScreenLBLCondominium
            // 
            HomeScreenLBLCondominium.AutoSize = true;
            HomeScreenLBLCondominium.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeScreenLBLCondominium.ForeColor = Color.White;
            HomeScreenLBLCondominium.Location = new Point(45, 14);
            HomeScreenLBLCondominium.Name = "HomeScreenLBLCondominium";
            HomeScreenLBLCondominium.Size = new Size(96, 21);
            HomeScreenLBLCondominium.TabIndex = 1;
            HomeScreenLBLCondominium.Text = "Condominio";
            toolTip1.SetToolTip(HomeScreenLBLCondominium, "Ir al módulo de Condominio");
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.condominium_white;
            pictureBox2.Location = new Point(9, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Ir al módulo de Condominio");
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(217, 217, 217);
            panel3.Controls.Add(HomeScreenLBLTitle);
            panel3.Location = new Point(170, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(1032, 59);
            panel3.TabIndex = 2;
            // 
            // HomeScreenLBLTitle
            // 
            HomeScreenLBLTitle.AutoSize = true;
            HomeScreenLBLTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HomeScreenLBLTitle.Location = new Point(21, 15);
            HomeScreenLBLTitle.Name = "HomeScreenLBLTitle";
            HomeScreenLBLTitle.Size = new Size(99, 30);
            HomeScreenLBLTitle.TabIndex = 0;
            HomeScreenLBLTitle.Text = "Principal";
            // 
            // HomeScreenPNLMain
            // 
            HomeScreenPNLMain.BackColor = Color.White;
            HomeScreenPNLMain.Location = new Point(170, 128);
            HomeScreenPNLMain.Name = "HomeScreenPNLMain";
            HomeScreenPNLMain.Size = new Size(1032, 631);
            HomeScreenPNLMain.TabIndex = 3;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 759);
            Controls.Add(HomeScreenPNLMain);
            Controls.Add(panel3);
            Controls.Add(HomeScreenPNLMenu);
            Controls.Add(panel1);
            Name = "HomeScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeScreen";
            Load += HomeScreen_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HomeScreenBTNLogOut).EndInit();
            HomeScreenPNLMenu.ResumeLayout(false);
            HomeScreenPNLUsers.ResumeLayout(false);
            HomeScreenPNLUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            HomeScreenPNLMaintenance.ResumeLayout(false);
            HomeScreenPNLMaintenance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            HomeScreenPNLFurniture.ResumeLayout(false);
            HomeScreenPNLFurniture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            HomeScreenPNLInvoice.ResumeLayout(false);
            HomeScreenPNLInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            HomeScreenPNLIncidence.ResumeLayout(false);
            HomeScreenPNLIncidence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            HomeScreenPNLTenant.ResumeLayout(false);
            HomeScreenPNLTenant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            HomeScreenPNLHousing.ResumeLayout(false);
            HomeScreenPNLHousing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            HomeScreenPNLHouseBlocks.ResumeLayout(false);
            HomeScreenPNLHouseBlocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            HomeScreenPNLCondominium.ResumeLayout(false);
            HomeScreenPNLCondominium.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel HomeScreenPNLMenu;
        private Label label1;
        private Label HomeScreenLBLTitleName;
        private PictureBox HomeScreenBTNLogOut;
        private Panel HomeScreenPNLCondominium;
        private PictureBox pictureBox2;
        private Label HomeScreenLBLCondominium;
        private Panel HomeScreenPNLHouseBlocks;
        private Label HomeScreenLBLHouseBlocks;
        private PictureBox pictureBox3;
        private Panel HomeScreenPNLHousing;
        private Label HomeScreenLBLHousing;
        private PictureBox pictureBox4;
        private Panel HomeScreenPNLIncidence;
        private Label HomeScreenLBLIncidence;
        private PictureBox pictureBox6;
        private Panel HomeScreenPNLTenant;
        private Label HomeScreenLBLTenant;
        private PictureBox pictureBox5;
        private Panel HomeScreenPNLInvoice;
        private Label HomeScreenLBLInvoice;
        private PictureBox pictureBox7;
        private Panel HomeScreenPNLFurniture;
        private Label HomeScreenLBLFurniture;
        private PictureBox pictureBox8;
        private Panel panel3;
        private Panel HomeScreenPNLMaintenance;
        private Label HomeScreenLBLMaintenance;
        private PictureBox pictureBox9;
        private Label HomeScreenLBLTitle;
        private Panel HomeScreenPNLUsers;
        private Label HomeScreenLBLUsers;
        private PictureBox pictureBox10;
        private Panel HomeScreenPNLMain;
        private ToolTip toolTip1;
    }
}