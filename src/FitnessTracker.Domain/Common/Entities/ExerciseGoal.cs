using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Common.Entities
{
    public abstract class ExerciseGoal : BaseEntity
    {
        public float? TargetLiftingWeight { get; set; }
        public EnumWeightUnitOfMeasurement? TargetLiftingWeightUnitOfMeasurement { get; set; }
        public int? TargetRepNumber { get; set; }
        public int? TargetSetNumber { get; set; }
        public float? TargetDuration { get; set; }
        public EnumDurationUnitOfMeasurement? TargetDurationUnitOfMeasurement { get; set; }
        public float? TargetDistance { get; set; }
        public EnumDistanceUnitOfMeasurement? TargetDistanceUnitOfMeasurement { get; set; }
    }
}
