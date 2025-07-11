using FluentValidation;
using StaffControl.Application.DTOs.Base;

namespace StaffControl.Application.Validators.Base
{
    public class BaseReceptionistValidator<T> : AbstractValidator<T> where T : ReceptionistBase
    {
        public BaseReceptionistValidator() 
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50);

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50);

            RuleFor(d => d.MiddleName)
                .MaximumLength(50);
        }
    }
}
