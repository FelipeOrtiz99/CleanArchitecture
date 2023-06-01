using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "4413ea81-5142-4dc9-8644-69085e37f350",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Felipe",
                    Apellidos = "Ortiz",
                    UserName = "FelipeOrtiz",
                    NormalizedUserName = "FelipeOrtiz",
                    PasswordHash = hasher.HashPassword(null, "VaxiDrez2025$"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "35b65dae-a1f6-4d10-9939-bd343a30f34c",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "Juanperez",
                    NormalizedUserName = "Juanperez",
                    PasswordHash = hasher.HashPassword(null, "VaxiDrez2025$"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
