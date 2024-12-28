using eCommerce.Core.Domain.Entities;

namespace eCommerce.Core.Domain.IRepositories;

public interface IUsersRepository
{
    Task<ApplicationUser> AddUser(ApplicationUser user);
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
