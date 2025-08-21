using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System_Reports
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void ConfigurarReporte(int idCondominio, string parametroExtra = "")
        {
            // Aquí pones la lógica que ya tienes para cargar el reporte
            // Ejemplo:
            ReportDocument reporte = new ReportDocument();
            reporte.Load(@"Reporte\CrystalReport123.rpt");
            reporte.SetParameterValue("@ID_Condominio", idCondominio);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.Refresh();
        }
    }
}
