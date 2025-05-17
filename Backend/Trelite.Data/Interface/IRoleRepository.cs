using System;
using Trelite.Data.Models;

namespace Trelite.Data.Interface;

public interface IRoleRepository
{
    Task<List<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int roleId);
}
