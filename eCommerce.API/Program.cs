using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraStructure();
builder.Services.AddCore();

// Web API Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // To convert string to enum
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

// Build the Web Application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller Routes
app.MapControllers();

app.Run();
