using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSpecialization
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<TrainerSpecialization> TrainerSpecializations { get; set; } = new List<TrainerSpecialization>();
        public ICollection<ExerciseSpecialization> ExerciseSpecializations { get; set; } = new List<ExerciseSpecialization>();
    }
}
