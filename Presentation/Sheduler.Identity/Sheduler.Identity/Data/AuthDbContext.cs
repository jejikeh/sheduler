using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sheduler.Identity.Models;

namespace Sheduler.Identity.Data;

public class AuthDbContext : IdentityDbContext<AppUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(typeBuilder => typeBuilder.ToTable(name: "Users"));
        builder.Entity<IdentityRole>(typeBuilder => typeBuilder.ToTable(name: "Roles"));
        builder.Entity<IdentityUserRole<string>>(typeBuilder => typeBuilder.ToTable(name: "UserRoles"));
        builder.Entity<IdentityUserClaim<string>>(typeBuilder => typeBuilder.ToTable(name: "UserClaim"));
        builder.Entity<IdentityUserLogin<string>>(typeBuilder => typeBuilder.ToTable("UserLogins"));
        builder.Entity<IdentityUserToken<string>>(typeBuilder => typeBuilder.ToTable("UserTokens"));
        builder.Entity<IdentityRoleClaim<string>>(typeBuilder => typeBuilder.ToTable("RoleClaims"));

        builder.ApplyConfiguration(new AppUserConfiguration());
    }
}