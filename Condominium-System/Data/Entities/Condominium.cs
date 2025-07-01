using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Condominium : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ReceptionContactNumber { get; set; }
        public string BlockCount { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Block> Blocks { get; set; }
    }
}
