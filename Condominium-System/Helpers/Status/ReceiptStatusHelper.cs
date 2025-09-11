using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Helpers.Status
{
    public static class ReceiptStatusHelper
    {
        public const string Pending = "Pending";
        public const string PartiallyPaid = "PartiallyPaid";
        public const string Completed = "Completed";

        public static string CalculateStatus(int amount, int amountPaid)
        {
            if (amountPaid == 0)
                return Pending;
            else if (amountPaid < amount)
                return PartiallyPaid;
            else
                return Completed;
        }

        public static bool IsValidStatus(string status)
        {
            return status == Pending || status == PartiallyPaid || status == Completed;
        }
    }
}
