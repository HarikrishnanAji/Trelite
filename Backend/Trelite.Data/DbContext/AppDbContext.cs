

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trelite.Data.Models;

namespace Trelite.Data.DbContext;

public class AppDbContext:IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    public User Users { get; set; }
    public Role Roles { get; set; }

}
