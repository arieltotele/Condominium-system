using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Payment: BaseModel
    {
        public DateTime Date { get; set; }
        public int AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Detail { get; set; }

        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
