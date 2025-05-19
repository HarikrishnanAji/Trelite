using System;
using Trelite.API.DTO;

namespace Trelite.Business.Interface;

public interface IAuthManager
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<string> LoginAsync(LoginDto loginDto);
}
