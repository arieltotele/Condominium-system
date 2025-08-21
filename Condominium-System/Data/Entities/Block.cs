using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Block : BaseModel
    {
        public string Name { get; set; }
        public string Feature { get; set; }
        public string HousingType { get; set; }
        public int HousingCount { get; set; }
        public string Address { get; set; }

        public int CondominiumId { get; set; }
        public virtual Condominium Condominium { get; set; }

        public virtual ICollection<Housing> Housings { get; set; }
    }
}
