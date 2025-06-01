using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WeightGoal
    {
        public Guid Id { get; set; }
        public decimal TargetWeight { get; set; }
        public string Unit { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
        public EnumWeightGoalStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CreatedByAccountId { get; set; }
        public Account CreatedByAccount { get; set; } = null!;
    }
}
