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
                Console.WriteLine($"Ruta actual: {Directory.GetCurrentDirectory()}");
                Console.WriteLine($"Intentando cargar reporte desde: {GetReportPath("CondominiumReport.rpt")}");

                var report = new ReportDocument();
                string reportPath = GetReportPath("CondominiumReport.rpt");

                Console.WriteLine($"¿Existe el archivo?: {File.Exists(reportPath)}");

                report.Load(reportPath); // Punto de fallo común 1
                report.SetParameterValue("@CondominiumId", condominiumId); // Punto de fallo 2
                report.SetParameterValue("@CondominiumName", condominiumName);

                using (var viewer = new ReportViewerForm())
                {
                    viewer.LoadReport(report); // Punto de fallo 3
                    viewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Log detallado
                File.AppendAllText("report_errors.log", $"[{DateTime.Now}] ERROR: {ex}\n\n");
                throw; // Relanza para manejo en la UI
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
