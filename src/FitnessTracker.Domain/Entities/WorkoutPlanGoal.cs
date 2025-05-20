using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class WorkoutPlanGoal : ExerciseGoal
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float? TargetBodyWeight { get; set; }
        public EnumWeightUnitOfMeasurement? TargetBodyWeightUnitOfMeasurement { get; set; }
        public EnumWorkoutPlanGoalStatus Status { get; set; }

        public Guid WorkoutPlanId { get; set; }
        public Guid? WorkoutExerciseId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = new WorkoutPlan();
        public WorkoutExercise? WorkoutExercise { get; set; }
    }
}
