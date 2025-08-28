using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Receipt: BaseModel
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int Amount { get; set; }
        public int AmountPaid { get; set; } = 0;
        public string? Detail { get; set; }
        public string? Status { get; set; }

        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public int HousingId { get; set; }
        public virtual Housing Housing { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
