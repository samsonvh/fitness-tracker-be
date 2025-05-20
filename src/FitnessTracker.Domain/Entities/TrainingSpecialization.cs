using FitnessTracker.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Entities
{
    public class TrainingSpecialization : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual List<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
