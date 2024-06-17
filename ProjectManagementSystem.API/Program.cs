using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectManagementSystem.Infrastucture.HostedServices;
using ProjectManagementSystem.Infrastucture.SchemaFilters;
using ProjectManagementSystem.Infrastucture.Validators.Behaviors;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Data.UnitOfWork;
using System.Reflection;
using System.Text.Json.Serialization;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Infrastucture.Services;
using ProjectManagementSystem.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(m =>
{
    var assembly = Assembly.Load("ProjectManagementSystem.Application");

    m.RegisterServicesFromAssembly(assembly);

    m.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins("https://localhost:7096")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true));
});

builder.Services.AddMassTransit(options =>
{
    options.AddConsumers(typeof(Program).Assembly);

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

builder.Services.AddScoped<IFileManager, FileManager>();

builder.Services.AddHostedService<ApplyMigrationService>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Project management system",
            Version = "v1",
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Project management system v1"));

app.UseReDoc(options =>
{
    options.DocumentTitle = "Project management system v1";
    options.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseAuthorization();

app.MapControllers()
    .RequireCors();


app.Run();