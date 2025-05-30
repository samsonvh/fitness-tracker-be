using FitnessTracker.Application.Common.Dtos;
using FitnessTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Common.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> IsEmailAvailableAsync(string email, CancellationToken cancellationToken);
        Task<bool> IsUsernameAvailableAsync(string username, CancellationToken cancellationToken);
        Task AddAsTrainerByEmailAsync(Account account, IEnumerable<TrainingSpecializationListDto> trainingSpecializations, CancellationToken cancellationToken);
        Task AddAsClientByEmailAsync(Account account, CancellationToken cancellationToken);
        Task<Account?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
