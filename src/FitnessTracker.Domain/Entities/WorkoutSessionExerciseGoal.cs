using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WorkoutSessionExerciseGoal : ExerciseGoal
    {
        public EnumWorkoutSessionExerciseGoalStatus Status { get; set; }

        public Guid WorkoutSessionId { get; set; }
        public Guid WorkoutExerciseId { get; set; }
        public WorkoutSession WorkoutSession { get; set; } = new WorkoutSession();
        public WorkoutExercise WorkoutExercise { get; set; } = new WorkoutExercise();
    }
}
