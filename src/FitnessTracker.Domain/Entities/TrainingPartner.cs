using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingPartner : AuditableEntity
    {
        public EnumTrainingPartnerStatus Status { get; set; }

        public Guid ClientId { get; set; }
        public Guid TrainerId { get; set; }
        public Guid TrainingSpecializationId { get; set; }
        public Account Client { get; set; } = new Account();
        public Account Trainer { get; set; } = new Account();
        public TrainingSpecialization TrainingSpecialization { get; set; } = new TrainingSpecialization();
    }
}
