using FluentValidation;
using PatientControl.Application.DTOs.Interfaces;

namespace PatientControl.Application.Validators
{
    public class BasePatientValidator<T> : AbstractValidator<T> where T : IPatientBase
    {
        protected BasePatientValidator() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50);

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50);

            RuleFor(p => p.MiddleName)
                .MaximumLength(50);

            RuleFor(p => p.DateOfBirth)
                .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");
        }
    }
}
