using StaffControl.Application.Interfaces;
using StaffControl.Application.Mappings;
using StaffControl.Application.Services;
using StaffControl.Domain.Interfaces;
using StaffControl.Infrastructure.Middleware;
using StaffControl.Infrastructure.Repositories;
using StaffControl.Infrastructure.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.AddValidation();

builder.AddRabbitMq();

builder.AddAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddSwagger();


builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
builder.Services.AddScoped<IReceptionistService, ReceptonistService>();


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
