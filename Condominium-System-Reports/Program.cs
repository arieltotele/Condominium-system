using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System_Reports
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Obtener parámetros
            if (args.Length >= 1)
            {
                int idCondominio = int.Parse(args[0]);
                string nombre = args.Length > 1 ? args[1] : "";

                var reportForm = new Form2();
                reportForm.ConfigurarReporte(idCondominio, nombre);
                Application.Run(reportForm);
            }
            else
            {
                MessageBox.Show("No se recibieron parámetros válidos");
            }
        }
    }
}
