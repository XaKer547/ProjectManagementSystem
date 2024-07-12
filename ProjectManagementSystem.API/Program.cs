using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectManagementSystem.API.HostedServices;
using ProjectManagementSystem.API.Middlewares;
using ProjectManagementSystem.API.SchemaFilters;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.API.Validators.Behaviors;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Infrastucture.Data;
using ProjectManagementSystem.Infrastucture.Data.UnitOfWork;
using System.Reflection;
using System.Text.Json.Serialization;
using static IdentityModel.OidcConstants;

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
    var origins = builder.Configuration["AllowedOrigins"]!.Split(';');

    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins(origins)
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "oidc";
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["SmartCollege.SSO.Base"];

        options.RequireHttpsMetadata = false;

        options.ClientId = "ProjectManagementSystem.API";

        options.ClientSecret = "4d0dabf05d184decbbaae4acc9e89a81";

        options.ResponseType = GrantTypes.ClientCredentials;

        options.Scope.Clear();
        options.Scope.Add("fullaccess");

        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;

        var handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };

        options.BackchannelHttpHandler = handler;
    });


builder.Services.AddDbContext<ProjectManagementSystemDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SmartCollegeConnection"));
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

    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Пожалуйста вставьте Bearer вместе с токеном в это поле",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
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

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseAuthorization();

app.MapControllers()
    .RequireCors();

app.Run();