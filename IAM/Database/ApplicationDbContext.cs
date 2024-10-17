using System;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using IAM.Claims;
using IAM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IAM.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Define DbSets for Identity
    public DbSet<User> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
    public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
    public DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
    public DbSet<IdentityRoleClaim<string>> RoleClaims { get; set; }
    public DbSet<IdentityUserToken<string>> UserTokens { get; set; }

    // Configure the Identity tables in OnModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        // Convert CustomClaims Dictionary as it is not by Ef core automatically

        builder.Entity<User>()
        .Property(x => x.CustomClaims)
        .HasConversion(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
            v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, new JsonSerializerOptions())
        );

        // Manually configure Identity table names if necessary
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        // Configure composite primary keys for Identity tables
        builder.Entity<IdentityUserRole<string>>()
            .HasKey(u => new { u.UserId, u.RoleId });

        builder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        builder.Entity<IdentityUserToken<string>>()
            .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
    }
}
