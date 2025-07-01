using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Service : BaseModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }

        public virtual ICollection<HousingService> Housings { get; set; }
    }
}
