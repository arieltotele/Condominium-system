using Condominium.System.Reports.Library.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Condominium.System.Reports.Library.Reports
{
    public static class ReportService
    {
        public static void ShowCondominiumReport(int condominiumId, string condominiumName)
        {
            try
            {
                var report = new ReportDocument();
                string reportPath = GetReportPath("CondominiumReport.rpt");

                if (!File.Exists(reportPath))
                    throw new FileNotFoundException($"No se encontró el reporte en: {reportPath}");

                report.Load(reportPath);

                report.SetParameterValue("@CondominiumId", condominiumId);
                report.SetParameterValue("@CondominiumName", condominiumName);

                using (var viewer = new ReportViewerForm())
                {
                    viewer.LoadReport(report);
                    viewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al generar el reporte", ex);
            }
        }

        private static string GetReportPath(string reportName)
        {
            string baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string reportsDir = Path.Combine(baseDir, "Reports");

            if (!Directory.Exists(reportsDir))
                Directory.CreateDirectory(reportsDir);

            return Path.Combine(reportsDir, reportName);
        }
    }
}
