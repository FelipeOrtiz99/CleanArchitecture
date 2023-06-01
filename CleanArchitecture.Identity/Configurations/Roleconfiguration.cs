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
    public class Roleconfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b378fda5-1b37-44e9-b560-1913c9ca94af",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = "cf7b11f4-cb50-4885-aa73-b3d92a87003f",
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                }
                );
        }
    }
}
