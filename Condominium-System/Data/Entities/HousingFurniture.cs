using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class HousingFurniture : AuditableModel
    {
        public int HousingId { get; set; }
        public virtual Housing Housing { get; set; }

        public int FurnitureId { get; set; }
        public virtual Furniture Furniture { get; set; }
    }
}
