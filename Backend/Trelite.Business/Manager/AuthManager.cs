using System;
using Trelite.API.DTO;
using Trelite.Business.Common;
using Trelite.Business.Interface;
using Trelite.Data.Interface;
using Trelite.Data.Models;
using Trelite.Data.Repository;

namespace Trelite.Business.Manager;

public class AuthManager:IAuthManager
{
    private readonly IUserRepository _userRepository;
    public AuthManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var error = "";
        try
        {
            var isUserExists = await _userRepository.GetUserByName(registerDto.UserName);
            if (isUserExists != null)
            {
                return Message.USER_EXISTS;
            }
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                RoleId = registerDto.RoleId,
                Dc = DateTime.Now,
                Lu = DateTime.Now,
                RV = Constants.RV_Default_Value
            };
            await _userRepository.SaveUserAsync(user);
            // response = Message.SUCCESS_REGISTERATION;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            Console.WriteLine(ex);
        }      
        return error;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var error = "";
        try
        {
            var user = await _userRepository.GetUserByName(loginDto.UserName);
            if (user == null||!BCrypt.Net.BCrypt.Verify(loginDto.UserName,user.PasswordHash))
            {
                error = Message.INVALID_USER;
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
            Console.WriteLine(ex);
        }
        return error;
    }
}
