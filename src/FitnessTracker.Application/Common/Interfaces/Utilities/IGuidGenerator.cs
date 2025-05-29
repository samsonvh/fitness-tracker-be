using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Common.Interfaces.Utilities
{
    public interface IGuidGenerator
    {
        Guid GenerateSequentialGuid();
    }
}
