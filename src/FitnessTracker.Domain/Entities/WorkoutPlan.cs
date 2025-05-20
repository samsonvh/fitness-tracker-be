using FitnessTracker.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WorkoutPlan : AuditableEntityIncludingCredit
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public bool IsWithTrainer { get; set; }

        public Guid ClientId { get; set; }
        public Guid? TrainerId { get; set; }
        public Account Client { get; set; } = new Account();
        public Account? Trainer { get; set; }

        public virtual List<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}
