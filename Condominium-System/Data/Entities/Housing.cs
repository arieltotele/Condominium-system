using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Housing : BaseModel
    {
        public string Code { get; set; }
        public int PeopleCount { get; set; }
        public int RoomCount { get; set; }
        public int BathroomCount { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }

        public ICollection<HousingService> Services { get; set; }
        public ICollection<HousingFurniture> Furnitures { get; set; }
        public ICollection<Tenant> Tenants { get; set; }
    }
}
