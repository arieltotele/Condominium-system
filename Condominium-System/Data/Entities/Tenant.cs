using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public class Tenant : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime EntryDate { get; set; }

        public int HousingId { get; set; }
        public virtual Housing Housing { get; set; }

        public virtual ICollection<Incident> Incidents { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
