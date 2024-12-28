using eCommerce.Core.Domain.IRepositories;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfraStructure(this IServiceCollection services)
    {
        services.AddTransient<DapperDbContext>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        //return services;
    }
}
