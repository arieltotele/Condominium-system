using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class HousingService : AuditableEntity
    {
        public int HousingId { get; set; }
        public Housing Housing { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
