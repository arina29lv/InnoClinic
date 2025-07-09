using FluentValidation;
using PatientControl.Application.DTOs;
namespace PatientControl.Application.Validators
{
    public class UpdatePatientValidator : AbstractValidator<UpdatePatientDto>
    {
        public UpdatePatientValidator() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First Name requared.")
                .MaximumLength(50);

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last Name requared.")
                .MaximumLength(50);

            RuleFor(p => p.MiddleName)
                .MaximumLength(50);

            RuleFor(p => p.DateOfBirth)
                .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

        }
    }
}
