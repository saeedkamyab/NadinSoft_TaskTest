using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ns.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ns.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hash = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "1",
                    Email = "saeed.kamyab@yahoo.com",
                    NormalizedEmail = "SAEED.KAMYAB@YAHOO.COM",
                    FirstName = "Saeid",
                    LastName = "Kamyab",
                    UserName = "saeed.kamyab@yahoo.com",
                    NormalizedUserName = "SAEED.KAMYAB@YAHOO.COM",
                    PasswordHash = hash.HashPassword(null,"1234")
                }); 
        }
    }
}
