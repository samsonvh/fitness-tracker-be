using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSessionLog
    {
        public Guid Id { get; set; }
        public int? RepsCompleted { get; set; }
        public int? SetsCompleted { get; set; }
        public decimal? LiftedWeight { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid TrainingSessionId { get; set; }
        public Guid TrainingExerciseId { get; set; }
        public Guid CreatedByAccountId { get; set; }
        public TrainingSession TrainingSession { get; set; } = null!;
        public TrainingExercise TrainingExercise { get; set; } = null!;
        public Account CreatedByAccount { get; set; } = null!;
    }
}
