using FitnessTracker.Application.Common.Interfaces.Repositories;
using FitnessTracker.Application.Common.Interfaces.Utilities;
using FitnessTracker.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Trainer.Commands.LoginByEmail
{
    public record TrainerLoginByEmailCommand(string Email, string Password) : IRequest<string>;

    public class TrainerLoginByEmailCommandHandler : IRequestHandler<TrainerLoginByEmailCommand, string>
    {
        private readonly IAccountWriteRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;

        public TrainerLoginByEmailCommandHandler(IAccountWriteRepository accountRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string> Handle(TrainerLoginByEmailCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (account == null)
            {
                throw new ArgumentException("Account with the provided email does not exist.");
            }

            if (!_passwordHasher.Verify(request.Password, account.PasswordHash))
            {
                throw new ArgumentException("Invalid password.");
            }

            if (account.Role != EnumAccountRole.Trainer)
            {
                throw new ArgumentException("Account is not a trainer.");
            }

            return _jwtGenerator.GenerateToken(account.Username, account.Role);
        }
    }
}
