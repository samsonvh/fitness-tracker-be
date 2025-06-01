using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSession
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; } = null!;

        public ICollection<TrainingSessionGoal> TrainingSessionGoals { get; set; } = new List<TrainingSessionGoal>();
        public ICollection<TrainingSessionLog> TrainingSessionLogs { get; set; } = new List<TrainingSessionLog>();
    }
}
