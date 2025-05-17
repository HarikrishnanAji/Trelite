using System;
using Trelite.Data.Models;

namespace Trelite.Data.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAllUserAsync();
    Task<User> GetUserByIdAsync(int userId);
    Task<User> SaveUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
}
