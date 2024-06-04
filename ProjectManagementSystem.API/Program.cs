using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.API.Validators.Behaviors;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Data.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(m =>
{
    var assembly = Assembly.Load("ProjectManagementSystem.Application");

    m.RegisterServicesFromAssembly(assembly);

    m.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMassTransit(options =>
{
    options.UsingRabbitMq((context, conf) =>
    {
        conf.Host("localhost", 5672, "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
    });
});

builder.Services.AddDbContext<ProjectManagementSystemDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PgLocalConnection"));
});

builder.Services.AddScoped<IProjectManagementSystemRepository, ProjectManagementSystemDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();