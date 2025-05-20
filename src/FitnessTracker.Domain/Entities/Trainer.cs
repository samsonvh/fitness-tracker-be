using FitnessTracker.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }

        public Guid AccountId { get; set; }
        public Guid? TrainingSpecializationId { get; set; }
        public Account Account { get; set; } = new Account();
        public TrainingSpecialization? TrainingSpecialization { get; set; }
    }
}
