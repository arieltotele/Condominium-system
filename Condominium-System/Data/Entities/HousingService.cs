using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class HousingService : AuditableModel
    {
        public int HousingId { get; set; }
        public virtual Housing Housing { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
