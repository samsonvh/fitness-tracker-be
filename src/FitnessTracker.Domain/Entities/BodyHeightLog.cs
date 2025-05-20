using FitnessTracker.Domain.Common.Entities;
using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class BodyHeightLog : AuditableEntityIncludingCredit
    {
        public float BodyHeight { get; set; }
        public EnumHeightUnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
