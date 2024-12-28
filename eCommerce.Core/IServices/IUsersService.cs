using System;
using eCommerce.Core.DTO;

namespace eCommerce.Core.IServices;

public interface IUsersService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest login);

    /// <summary>
    /// Method to handle user registration use case
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest login);
}
