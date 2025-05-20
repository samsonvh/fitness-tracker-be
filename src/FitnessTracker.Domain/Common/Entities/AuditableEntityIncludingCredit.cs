using FitnessTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Common.Entities
{
    public abstract class AuditableEntityIncludingCredit : AuditableEntity
    {
        public Guid CreatedById { get; set; }
        public Account CreatedBy { get; set; } = new Account();
        public Guid? UpdatedById { get; set; }
        public Account? UpdatedBy { get; set; }
    }
}
