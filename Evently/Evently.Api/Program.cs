using Evently.Api.Extensions;
using Evently.Events.Application.Interfaces;
using Evently.Events.Domain.Entities;
using Evently.Events.Infrastructure.Database.Context;
using Evently.Events.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Event).Assembly));

builder.Services
    .AddTransient<IEventsRepository, EventsRepository>();

builder.Services.AddDbContext<EventsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"))
);

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