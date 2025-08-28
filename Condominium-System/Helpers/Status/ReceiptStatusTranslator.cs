using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Helpers.Status
{
    public static class ReceiptStatusTranslator
    {
        public static string TranslateStatus(string status)
        {
            return status switch
            {
                "Pending" => "Pendiente",
                "PartiallyPaid" => "Parcialmente Pagado",
                "Completed" => "Completamente Pagado",
                _ => status // Por si acaso hay otros estatus
            };
        }

        public static string TranslateToEnglish(string statusSpanish)
        {
            return statusSpanish switch
            {
                "Pendiente" => "Pending",
                "Parcialmente Pagado" => "PartiallyPaid",
                "Completamente Pagado" => "Completed",
                _ => statusSpanish
            };
        }
    }
}
