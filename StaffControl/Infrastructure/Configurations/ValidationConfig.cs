using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using StaffControl.Application.Validators.DoctorValidator;

namespace StaffControl.Infrastructure.Configurations
{
    public static class ValidationConfig
    {
        public static void AddValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateDoctorValidator>();
            
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
            });
        }
    }
}
