using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class ExerciseSpecialization
    {
        public Guid Id { get; set; }

        public Guid TrainingSpecializationId { get; set; }
        public Guid TrainingExerciseId { get; set; }
        public TrainingSpecialization TrainingSpecialization { get; set; } = null!;
        public TrainingExercise TrainingExercise { get; set; } = null!;
    }
}
