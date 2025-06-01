using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSessionGoal
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public int? TargetReps { get; set; }
        public int? TargetSets { get; set; }
        public decimal? TargetLiftingWeight { get; set; }
        public EnumTrainingSessionGoalStatus Status { get; set; }

        public Guid TrainingSessionId { get; set; }
        public Guid TrainingExerciseId { get; set; }
        public TrainingSession TrainingSession { get; set; } = null!;
        public TrainingExercise TrainingExercise { get; set; } = null!;
    }
}
