using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Condominium.System.Reports.Library.Forms
{
    partial class ReportViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = Cursors.Default;
            this.crystalReportViewer.Dock = DockStyle.Fill;
            this.crystalReportViewer.Location = new Point(0, 0);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new Size(800, 450);
            this.crystalReportViewer.TabIndex = 0;
            // 
            // ReportViewerForm
            // 
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.crystalReportViewer);
            this.Name = "ReportViewerForm";
            this.Text = "Visualizador de Reportes";
            this.ResumeLayout(false);

        }

        #endregion
    }
}