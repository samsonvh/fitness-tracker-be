using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public EnumAccountRole Role { get; set; }
        public EnumAccountStatus Status { get; set; }

        public virtual List<WorkoutPlan> CreatedWorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public virtual List<WorkoutPlan> AssignedWorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public virtual List<BodyWeightLog> CreatedBodyWeightLogs { get; set; } = new List<BodyWeightLog>();
        public virtual List<BodyWeightLog> UpdatedBodyWeightLogs { get; set; } = new List<BodyWeightLog>();
        public virtual List<BodyHeightLog> CreatedBodyHeightLogs { get; set; } = new List<BodyHeightLog>();
        public virtual List<BodyHeightLog> UpdatedBodyHeightLogs { get; set; } = new List<BodyHeightLog>();
        public virtual List<WorkoutExercise> CreatedWorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }
}
