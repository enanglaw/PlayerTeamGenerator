// /////////////////////////////////////////////////////////////////////////////
// PLEASE DO NOT RENAME OR REMOVE ANY OF THE CODE BELOW. 
// YOU CAN ADD YOUR CODE TO THIS FILE TO EXTEND THE FEATURES TO USE THEM IN YOUR WORK.
// /////////////////////////////////////////////////////////////////////////////

using WebApi.Helpers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using WebApi;
using Microsoft.OpenApi.Models;
using WebApi.Contracts.Persistence;
using WebApi.Repositories;
using System.Reflection;
using WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata;
using Serilog;

_.__();

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    builder.WebHost.UseUrls("https://localhost:3000");
    builder.WebHost.ConfigureLogging((context, logging) =>
    {
        var config = context.Configuration.GetSection("Logging");
        logging.AddConfiguration(config);
        logging.AddConsole();
        logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
        logging.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Warning);
        logging.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);
    });
    builder.Services.AddIdentity<AppUsers, IdentityRole>(cfg =>
    {
        cfg.User.RequireUniqueEmail = true;
        cfg.Lockout.MaxFailedAccessAttempts = 3;
        cfg.Password.RequireNonAlphanumeric = true;
        cfg.Password.RequireDigit = true;
        cfg.Password.RequiredLength = 10;
        cfg.Password.RequireLowercase = true;
        cfg.Password.RequireLowercase = true;
                
    }).AddEntityFrameworkStores<DataContext>();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddCookie()
        .AddJwtBearer(
        authenticationScheme:JwtBearerDefaults.AuthenticationScheme,
        cfg =>
    {
        cfg.IncludeErrorDetails = true;        
        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
           // ValidIssuer =_config["JwtSettings:Issuer"],
          //  ValidAudience = _config["JwtSettings:Audience"],
          //  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_config["JwtSettings:Key"])),
            ValidateIssuer=true,
            ValidateAudience=true,
            ValidateLifetime=true,
            RequireExpirationTime=true
        };
    });

    builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
    builder.Services.AddScoped<IPlayerSkillRepository,PlayerSkillRepository>();
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

    var services = builder.Services;
    services.AddHttpContextAccessor();
    services.AddResponseCaching();
    services.AddResponseCompression(cfg =>
    {
        cfg.EnableForHttps = true;
    });
    services.AddControllers(cfg =>
    {
        cfg.RespectBrowserAcceptHeader = true;
    }).AddNewtonsoftJson(cfg =>
    {
       
        cfg.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }).AddXmlSerializerFormatters();

    services.AddCors(options =>
    {
        options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });
    services.AddSqlite<DataContext>("DataSource=webApi.db");

    services.AddDataProtection().UseCryptographicAlgorithms(
        new AuthenticatedEncryptorConfiguration
        {
            EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
            ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
        });
    services.AddSwaggerGen(c =>
    {


        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Course Tech Interview API",

        });


    });
}

var app = builder.Build()       
       .ConfigurePipeline();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.EnsureCreated();

}

// configure HTTP request pipeline
{
    app.UseCors();
    app.MapControllers();
    app.UseResponseCompression();
    app.UseResponseCaching();
  //  app.UseSerilogRequestLogging();
}

app.Run();

public partial class Program { }

