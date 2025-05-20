using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class BodyWeightGoal : AuditableEntityIncludingCredit
    {
        public float TargetBodyWeight { get; set; }
        public DateTime TargetDate { get; set; }
        public float BodyWeightChangeRate { get; set; }
        public EnumWeightUnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
