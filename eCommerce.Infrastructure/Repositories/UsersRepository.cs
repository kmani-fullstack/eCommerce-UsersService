using Dapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.IRepositories;
using eCommerce.Core.DTO;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository(DapperDbContext _dbContext) : IUsersRepository
{
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        
        // SQL Query to insert data in "Users" table
        var query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\",\"PersonName\",\"Gender\",\"Password\") "+ 
            " VALUES (@UserId,@Email,@PersonName,@Gender,@Password)";
        
        var rowsAffected = await _dbContext.DbConnection.ExecuteAsync(query,user);
        
        return rowsAffected > 0 ? user : null;
        
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var user =  await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { email, password });
        return user;
    }
}
