using FitnessTracker.Application.Common.Interfaces.Repositories;
using FitnessTracker.Application.Common.Interfaces.Utilities;
using FitnessTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Client.Commands.RegisterByEmail
{
    public record ClientRegisterByEmailCommand(
        string Email,
        string Password,
        string Username,
        string FirstName,
        string LastName,
        DateOnly DateOfBirth
    ) : IRequest;

    public class ClientRegisterByEmailCommandHandler : IRequestHandler<ClientRegisterByEmailCommand>
    {
        private readonly IAccountWriteRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IGuidGenerator _guidGenerator;

        public ClientRegisterByEmailCommandHandler(IAccountWriteRepository accountRepository, IPasswordHasher passwordHasher, IGuidGenerator guidGenerator)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _guidGenerator = guidGenerator;
        }

        public async Task Handle(ClientRegisterByEmailCommand request, CancellationToken cancellationToken)
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
                Role = Domain.Enums.EnumAccountRole.Client,
                Status = Domain.Enums.EnumAccountStatus.Active,
                CreatedAt = DateTime.UtcNow,
                PersonalProfile = personalProfile
            };

            await _accountRepository.AddAsClientByEmailAsync(account, cancellationToken);
        }
    }
}
