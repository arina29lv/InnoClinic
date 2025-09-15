using PatientControl.Application.Interfaces;
using PatientControl.Application.Mappings;
using PatientControl.Application.Services;
using PatientControl.Domain.Interfaces;
using PatientControl.Infrastructure.Middleware;
using PatientControl.Infrastructure.Repositories;
using PatientControl.Infrastructure.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.AddValidation();

builder.AddRabbitMq();

builder.AddAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddSwagger();


builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();


var app = builder.Build();

app.UseDatabaseInitialization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExeptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();