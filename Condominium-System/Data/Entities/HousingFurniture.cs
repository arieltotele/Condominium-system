using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class HousingFurniture : AuditableEntity
    {
        public int HousingId { get; set; }
        public Housing Housing { get; set; }

        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }
    }
}
