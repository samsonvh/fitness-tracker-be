using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingExercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public EnumPublicity Publicity { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid CreatedByAccountId { get; set; }
        public Account CreatedByAccount { get; set; } = null!;

        public ICollection<ExerciseSpecialization> ExerciseSpecializations { get; set; } = new List<ExerciseSpecialization>();
        public ICollection<TrainingSessionGoal> TrainingSessionGoals { get; set; } = new List<TrainingSessionGoal>();
        public ICollection<TrainingSessionLog> TrainingSessionLogs { get; set; } = new List<TrainingSessionLog>();
    }
}
