using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerivoxTest.Domain.Models.Entities
{
    public class AuditableEntity
    {
        public Guid CreatedBy { get; set; }

        public DateTime CreationOn { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
