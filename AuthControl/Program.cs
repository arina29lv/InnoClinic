using AuthControl.Application.Interfaces;
using AuthControl.Application.Services;
using AuthControl.Domain.Interfaces;
using AuthControl.Infrastructure.Configurations;
using AuthControl.Infrastructure.interfaces;
using AuthControl.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.AddJwtAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
