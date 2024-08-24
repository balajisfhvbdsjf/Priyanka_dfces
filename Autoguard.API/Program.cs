using Autoguard.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation;
using Autoguard.Application.Validators;
using Autoguard.Application.Mappings;
using Autoguard.Application.Features.Business.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autoguard.Application.Interfaces.Repositories;
using Autoguard.Application.Interfaces.Services;
using Autoguard.Application.Services;
using Autoguard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Set up Serilog for logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddControllers();

// Configure DbContext (AutoguardDbContext)
builder.Services.AddDbContext<AutoguardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IBusinessService, BusinessService>();

// Configure MediatR - scan for handlers in the same assembly as RegisterBusinessCommandHandler
builder.Services.AddMediatR(typeof(RegisterBusinessCommandHandler).Assembly);

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(BusinessMapProfile));

// Configure FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<BusinessValidator>();

// Add middleware for logging and error handling
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware for logging and error handling
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Start the application and log startup and shutdown events
try
{
    Log.Information("Starting the web application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}
