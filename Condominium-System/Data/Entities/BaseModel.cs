using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Data.Entities
{
    public abstract class BaseModel:AuditableModel
    {
        [Key]
        public int Id { get; set; }
    }

}
