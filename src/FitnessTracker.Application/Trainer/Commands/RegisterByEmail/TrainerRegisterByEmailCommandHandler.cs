using FitnessTracker.Application.Common.Dtos;
using FitnessTracker.Application.Common.Interfaces.Repositories;
using FitnessTracker.Application.Common.Interfaces.Utilities;
using FitnessTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Trainer.Commands.RegisterByEmail
{
    public record TrainerRegisterByEmailCommand(
        string Email,
        string Password,
        string Username,
        string FirstName,
        string LastName,
        DateOnly DateOfBirth,
        IEnumerable<TrainingSpecializationListDto> TrainerSpecializations
    ) : IRequest;

    public class TrainerRegisterByEmailCommandHandler : IRequestHandler<TrainerRegisterByEmailCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IGuidGenerator _guidGenerator;

        public TrainerRegisterByEmailCommandHandler(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IGuidGenerator guidGenerator)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _guidGenerator = guidGenerator;
        }

        public async Task Handle(TrainerRegisterByEmailCommand request, CancellationToken cancellationToken)
        {
            var personalProfile = new PersonalProfile
            {
                Id = _guidGenerator.GenerateSequentialGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            var account = new Account
            {
                Id = _guidGenerator.GenerateSequentialGuid(),
                Email = request.Email,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Username = request.Username,
                Role = Domain.Enums.EnumAccountRole.Trainer,
                Status = Domain.Enums.EnumAccountStatus.Active,
                CreatedAt = DateTime.UtcNow,
                PersonalProfile = personalProfile
            };

            await _accountRepository.AddAsTrainerByEmailAsync(account, request.TrainerSpecializations, cancellationToken);
        }
    }
}
