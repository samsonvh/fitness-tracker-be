using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainerSpecialization
    {
        public Guid Id { get; set; }

        public Guid TrainerAccountId { get; set; }
        public Guid TrainingSpecializationId { get; set; }
        public Account TrainerAccount { get; set; } = null!;
        public TrainingSpecialization TrainingSpecialization { get; set; } = null!;
    }
}
