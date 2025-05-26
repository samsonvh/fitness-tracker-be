using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public EnumAccountRole Role { get; set; }
        public EnumAccountStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public PersonalProfile? PersonalProfile { get; set; }

        public ICollection<Partnership> PartnershipsAsTrainer { get; set; } = new List<Partnership>();
        public ICollection<Partnership> PartnershipsAsClient { get; set; } = new List<Partnership>();
        public ICollection<TrainingPlan> CreatedTrainingPlans { get; set; } = new List<TrainingPlan>();
        public ICollection<TrainingPlan> AssignedTrainingPlans { get; set; } = new List<TrainingPlan>();
        public ICollection<TrainingExercise> CreatedTrainingExercises { get; set; } = new List<TrainingExercise>();
        public ICollection<TrainingSession> CreatedTrainingSessions { get; set; } = new List<TrainingSession>();
        public ICollection<TrainingSessionLog> CreatedTrainingSessionLogs { get; set; } = new List<TrainingSessionLog>();
        public ICollection<WeightLog> CreatedWeightLogs { get; set; } = new List<WeightLog>();
        public ICollection<WeightGoal> WeightGoals { get; set; } = new List<WeightGoal>();
    }
}
