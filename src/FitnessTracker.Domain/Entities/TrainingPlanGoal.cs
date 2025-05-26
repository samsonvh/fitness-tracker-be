using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingPlanGoal
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public float? TargetWeight { get; set; }
        public EnumTrainingPlanGoalStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; } = null!;
    }
}
