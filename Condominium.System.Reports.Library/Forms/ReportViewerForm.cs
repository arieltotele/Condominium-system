using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;

namespace Condominium.System.Reports.Library.Forms
{
    public partial class ReportViewerForm : Form
    {
        // Asegúrate que el control existe en el diseñador
        private CrystalReportViewer crystalReportViewer;

        public ReportViewerForm()
        {
            InitializeComponent();
        }

        // Método público para cargar el reporte
        public void LoadReport(ReportDocument report)
        {
            if (crystalReportViewer == null)
            {
                throw new InvalidOperationException("El control CrystalReportViewer no está inicializado");
            }

            crystalReportViewer.ReportSource = report;
            crystalReportViewer.Refresh();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}