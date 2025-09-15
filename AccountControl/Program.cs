using AccountControl.Application.Interfaces;
using AccountControl.Application.Mappings;
using AccountControl.Application.Services;
using AccountControl.Domain.Interfaces;
using AccountControl.Infrastructure.Middleware;
using AccountControl.Infrastructure.Repositories;
using AccountControl.Infrastructure.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.AddValidation();

builder.AddRabbitMq();

builder.AddAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddSwagger();


builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();


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