using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Invoice : BaseModel
    {
        public string Detail { get; set; }
        public DateTime IssueDate { get; set; }
        public string TotalAmount { get; set; }

        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
