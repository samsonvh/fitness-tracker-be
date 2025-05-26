using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WeightLog
    {
        public Guid Id { get; set; }
        public float Weight { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Guid CreatedByAccountId { get; set; }
        public Account CreatedByAccount { get; set; } = null!;
    }
}
