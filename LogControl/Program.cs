using LogControl.Application.Interfaces;
using LogControl.Application.Service;
using LogControl.Domain.Interfaces;
using LogControl.Infrastructure.Configurations;
using LogControl.Infrastructure.Messaging;
using LogControl.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.AddDatabaseContext();

builder.AddRabbitMq();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LogMessageConsumer>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();


var app = builder.Build();

app.UseDatabaseInitialization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
