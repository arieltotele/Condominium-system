using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Helpers
{
    public class Session
    {
        public static User? CurrentUser { get; set; }
        public static Housing? CurrentHouse { get; set; }
        public static Condominium? CondominiumToUpsert {  get; set; }
    }
}
