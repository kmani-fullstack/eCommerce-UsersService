using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x=>x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");
        
        RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

        RuleFor(x => x.Gender).IsInEnum().WithMessage("Gender is invalid.");
            
         RuleFor(x=>x.PersonName)
             .NotEmpty().WithMessage("Person Name is required.")
             .Length(6,100).WithMessage("Person Name must be between 6 and 100 characters.");
    }
}