using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Incident : BaseModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
