using System;
using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.IRepositories;
using eCommerce.Core.DTO;
using eCommerce.Core.IServices;

namespace eCommerce.Core.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest login)
    {
        var user = await usersRepository.GetUserByEmailAndPassword(login.Email, login.Password);

        if (user == null) return null;

        return mapper.Map<AuthenticationResponse>(user) with{ Success = true, Token = "token123"};
        //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, "XYZ", true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        
        var registeredUser = await usersRepository.AddUser(mapper.Map<ApplicationUser>(registerRequest));
        /*var registeredUser = await usersRepository.AddUser(new ApplicationUser
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString()
        });*/

        if (registeredUser == null) return null;

        return mapper.Map<AuthenticationResponse>(registeredUser) with{ Success = true, Token = "token123"};
        /*return new AuthenticationResponse(
            registeredUser.UserID,
            registeredUser.Email,
            registeredUser.PersonName,
             "XYZ", true);*/
    }
}
