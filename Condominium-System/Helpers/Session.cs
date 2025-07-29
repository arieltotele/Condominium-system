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
        public static Block? BlockToUpsert { get; set; }
        public static Tenant? TenantToUpsert { get; set; }
        public static Incident? IncidenceToUpsert { get; set; }
        public static Furniture? FurnitureToUpsert { get; set; }
        public static Service? ServiceToUpsert { get; set; }

        public static User? UserToUpsert { get; set; }
    }
}
