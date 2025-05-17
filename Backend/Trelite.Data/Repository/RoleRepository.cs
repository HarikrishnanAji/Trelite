using System;
using Trelite.Data.DbContext;
using Trelite.Data.Interface;
using Trelite.Data.Models;
using Trelite.Data.Repository.Base;

namespace Trelite.Data.Repository;

public class RoleRepository : BaseRepository<Role>,IRoleRepository
{
    protected readonly AppDbContext _appDbContext;
    private RoleRepository(AppDbContext appDbContext):base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await GetAsync();
    } 
    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        return await GetByIdAsync(roleId);
    }
}
