using Evently.Api.Extensions;
using Evently.Events.Application;
using Evently.Events.Application.Interfaces.Repositories;
using Evently.Events.Domain.Models;
using Evently.Events.Infrastructure;
using Evently.Events.Infrastructure.Database.Context;
using Evently.Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterInfrastructure(builder.Configuration);
builder.Services.RegisterApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();