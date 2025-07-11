using FluentValidation;
using StaffControl.Application.DTOs.Base;

namespace StaffControl.Application.Validators.Base
{
    public class BaseDoctorValidator<T> : AbstractValidator<T> where T : DoctorBase
    {
        public BaseDoctorValidator() 
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50);

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50);

            RuleFor(d => d.MiddleName)
                .MaximumLength(50);

            RuleFor(d => d.DateOfBirth)
                .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.");

            RuleFor(d => d.CareerStartYear)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Career start year cannot be in the future.");

            RuleFor(d => d.Status)
                .NotEmpty().WithMessage("Status is requared.")
                .MaximumLength(50);
        }
    }
}
