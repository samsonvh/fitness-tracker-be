using FitnessTracker.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WorkoutExercise : AuditableEntityIncludingCredit
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }

        public Guid TrainingSpecializationId { get; set; }
        public TrainingSpecialization TrainingSpecialization { get; set; } = new TrainingSpecialization();

        public virtual List<WorkoutPlanGoal> WorkoutPlanGoals { get; set; } = new List<WorkoutPlanGoal>();
        public virtual List<WorkoutSessionExerciseGoal> WorkoutSessionExerciseGoals { get; set; } = new List<WorkoutSessionExerciseGoal>();
        public virtual List<WorkoutSessionExerciseLog> WorkoutSessionExerciseLogs { get; set; } = new List<WorkoutSessionExerciseLog>();
    }
}
