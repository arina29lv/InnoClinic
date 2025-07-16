using AccountControl.Application.DTOs.Base;
using FluentValidation;

namespace AccountControl.Application.Validators.Base
{
    public class BaseAccountValidator<T> : AbstractValidator<T> where T : AccountBase
    {
        protected BaseAccountValidator() 
        {
            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100)
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(a => a.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .MaximumLength(20);
        }
    }
}
