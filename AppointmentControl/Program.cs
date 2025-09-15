using AppointmentControl.Application.Interfaces;
using AppointmentControl.Application.Mappings;
using AppointmentControl.Application.Services;
using AppointmentControl.Domain.Interfaces;
using AppointmentControl.Infrastructure.Configurations;
using AppointmentsControl.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.AddRabbitMq();

builder.AddAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddSwagger();


builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();


var app = builder.Build();

app.UseDatabaseInitialization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
