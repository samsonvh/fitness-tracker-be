using FitnessTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Common.Interfaces.Utilities
{
    public interface IJwtGenerator
    {
        string GenerateToken(string username, EnumAccountRole role);
    }
}
