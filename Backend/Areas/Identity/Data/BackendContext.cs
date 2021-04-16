using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class BackendContext : IdentityDbContext<
        BackendUser, BackendRole, string,
        IdentityUserClaim<string>, BackendUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>
        >
    {
        public BackendContext()
        {
        }

        public BackendContext(DbContextOptions<BackendContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            builder.Entity<BackendUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            builder.Entity<BackendRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            var roles = new[] { new BackendRole("Admin") };

            var users = new[]
            {
                new BackendUser
                {
                    Email = "sric111@lsu.edu",
                    UserName = "sric111@lsu.edu",
                    NormalizedUserName = StringNormalizationExtensions.Normalize("sric111@lsu.edu"),
                    Name = "Mr. Dowling",
                    CardHolderName = "Debbie Dowling",
                    CCNumber = "0000 8888 7777 6666",
                    ExpDate = "09/21",
                    SecurityNumber = 420,
                    BillingAddress = "1234 5th Ave, New York City, NY 10000",
                    Address = "1234 5th Ave",
                    State = "NY",
                    City = "New York City",
                    Country = "US",
                    ZipCode = "10000",
                    EmailConfirmed = true
                },
                new BackendUser
                {
                    Email = "holden@lsu.edu",
                    UserName = "holden@lsu.edu",
                    NormalizedUserName = StringNormalizationExtensions.Normalize("holden@lsu.edu"),
                    Name = "Seth Richard",
                    CardHolderName = "Seth Richard",
                    CCNumber = "0000 8888 7777 6666",
                    ExpDate = "09/21",
                    SecurityNumber = 420,
                    BillingAddress = "123 Rat St",
                    Address = "123 Rat St",
                    State = "RI",
                    City = "Rat City",
                    Country = "US",
                    ZipCode = "42069",
                    EmailConfirmed = true
                }
            };

            users[0].PasswordHash = new PasswordHasher<BackendUser>().HashPassword(users[0], "Superrat3#");
            users[1].PasswordHash = new PasswordHasher<BackendUser>().HashPassword(users[0], "Superrat3#");

            var userRoles = new[]
            {
                new BackendUserRole
                {
                    UserId = users[0].Id,
                    RoleId = roles[0].Id
                }
            };

            builder.Entity<BackendUser>().HasData(users);
            builder.Entity<BackendRole>().HasData(roles);
            builder.Entity<BackendUserRole>().HasData(userRoles);
        }
    }
}
