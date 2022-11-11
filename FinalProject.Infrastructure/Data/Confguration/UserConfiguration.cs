using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data.Confguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        public List<User> SeedUsers()
        {
            var users = new List<User>(); 
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                UserName = "guest1",
                NormalizedUserName = "guest1",
                Email = "guest1@gmail.com",
                NormalizedEmail = "guest1@gmail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "guest12345");
            users.Add(user);

            user = new User()
            {
                Id = "ebc5234d-a9cb-4ce0-9b9e-590b2e66d374",
                UserName = "guest2",
                NormalizedUserName = "guest2",
                Email = "guest2@gmail.com",
                NormalizedEmail = "guest2@gmail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin1234");
            users.Add(user);

            user = new User()
            {
                Id = "88fad1b1-c2c5-4e2b-ba98-16c87d7d01ca",
                UserName = "guest3",
                NormalizedUserName = "guest3",
                Email = "guest3@gmail.com",
                NormalizedEmail = "guest3@gmail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin123");
            users.Add(user);

            user = new User()
            {
                Id = "d58dadb8-e031-41e7-875e-da7378709cb5",
                UserName = "admin1",
                NormalizedUserName = "admin1",
                Email = "admin1@gmail.com",
                NormalizedEmail = "admin1@gmail.com"
            };

            user.PasswordHash = hasher.HashPassword(user, "admin12345");
            users.Add(user);


            return users;
        }
    }
}
