using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPersonalPlan { get; set; }
        public EnumTrainingPlanStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid? ClientAccountId { get; set; }
        public Guid CreatedByAccountId { get; set; }
        public Account? ClientAccount { get; set; }
        public Account CreatedByAccount { get; set; } = null!;

        public ICollection<TrainingPlanGoal> TrainingPlanGoals { get; set; } = new List<TrainingPlanGoal>();
        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
    }
}
