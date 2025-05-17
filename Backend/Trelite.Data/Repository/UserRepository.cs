using System;
using Trelite.Data.DbContext;
using Trelite.Data.Interface;
using Trelite.Data.Models;
using Trelite.Data.Repository.Base;

namespace Trelite.Data.Repository;

public class UserRepository:BaseRepository<User>,IUserRepository
{
    protected readonly AppDbContext _appDbContext;
    public UserRepository(AppDbContext appDbContext):base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        return await GetAsync();
    }
    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await GetByIdAsync(userId);
    }
    public async Task<User> SaveUserAsync(User user)
    {
        return await PostAsync(user);
    }
    public async Task<User> UpdateUserAsync(User user)
    {
        return await UpdateAsync(user);
    }
}
