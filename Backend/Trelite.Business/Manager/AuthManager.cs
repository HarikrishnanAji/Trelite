using System;
using Trelite.Business.Common;
using Trelite.Data.Models;
using Trelite.Data.Repository;

namespace Trelite.Business.Manager;

public class AuthManager
{
    protected readonly UserRepository _userRepository;
    public AuthManager(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> RegisterUserAsync(string userName,string email,string password, int roleId)
    {
        var user = new User
        {
            UserName = userName,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            RoleId = roleId,
            Dc = DateTime.Now,
            Lu = DateTime.Now,
            RV = Constants.RV_Default_Value
        };
        return await _userRepository.SaveUserAsync(user);
    }
}
