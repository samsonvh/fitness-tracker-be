using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Application.Trainer.Commands.RegisterByEmail
{
    public class TrainerRegisterByEmailCommandValidator : AbstractValidator<TrainerRegisterByEmailCommand>
    {
        public TrainerRegisterByEmailCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.DateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth must be in the past.");
            RuleFor(x => x.TrainerSpecializations)
                .Must(specs => specs.All(spec => spec != null && !string.IsNullOrWhiteSpace(spec.Name)))
                .WithMessage("Each specialization must have a valid name.");
        }
    }
}
