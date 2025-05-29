using FitnessTracker.Application.Common.Interfaces.Repositories;
using FitnessTracker.Application.Common.Interfaces.Utilities;
using FitnessTracker.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Client.Commands.LoginByEmail
{
    public record ClientLoginByEmailCommand(string Email, string Password) : IRequest<string>;

    public class ClientLoginByEmailCommandHandler : IRequestHandler<ClientLoginByEmailCommand, string>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtGenerator _jwtGenerator;

        public ClientLoginByEmailCommandHandler(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IJwtGenerator jwtGenerator)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<string> Handle(ClientLoginByEmailCommand request, CancellationToken cancellationToken)
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

            if (account.Role != EnumAccountRole.Client)
            {
                throw new ArgumentException("Account is not a client.");
            }

            return _jwtGenerator.GenerateToken(account.Username, account.Role);
        }
    }
}
