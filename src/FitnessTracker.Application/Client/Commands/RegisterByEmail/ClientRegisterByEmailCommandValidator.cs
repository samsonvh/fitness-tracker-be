using FitnessTracker.Application.Common.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Client.Commands.RegisterByEmail
{
    public class ClientRegisterByEmailCommandValidator : AbstractValidator<ClientRegisterByEmailCommand>
    {
        public ClientRegisterByEmailCommandValidator(IAccountWriteRepository accountWriteRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");
            RuleFor(x => x)
                .CustomAsync(async (command, context, cancellationToken) =>
                {
                    var (isUsernameTaken, isEmailTaken) = await accountWriteRepository.CheckAvailabilityAsync(command.Email, command.Username, cancellationToken);
                    if (isEmailTaken)
                    {
                        context.AddFailure(nameof(command.Email), "This email is already registered.");
                    }
                    if (isUsernameTaken)
                    {
                        context.AddFailure(nameof(command.Username), "This username is already taken.");
                    }
                });

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.DateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");
        }
    }
}
