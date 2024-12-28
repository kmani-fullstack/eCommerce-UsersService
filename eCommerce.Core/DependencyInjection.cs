using eCommerce.Core.IServices;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static void AddCore(this IServiceCollection services)
    {
        // Add services to IoC container
        services.AddTransient<IUsersService, UsersService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        //return services;
    }
}
