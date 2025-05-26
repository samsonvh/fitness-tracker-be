using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class Partnership
    {
        public Guid Id { get; set; }
        public EnumPartnershipStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TrainerAccountId { get; set; }
        public Guid ClientAccountId { get; set; }
        public Account TrainerAccount { get; set; } = null!;
        public Account ClientAccount { get; set; } = null!;
    }
}
