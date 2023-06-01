using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b378fda5-1b37-44e9-b560-1913c9ca94af",
                    UserId = "4413ea81-5142-4dc9-8644-69085e37f350"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cf7b11f4-cb50-4885-aa73-b3d92a87003f",
                    UserId = "35b65dae-a1f6-4d10-9939-bd343a30f34c"
                } 

                );
        }
    }
}
