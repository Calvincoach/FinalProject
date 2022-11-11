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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        public List<Category> SeedCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Music"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Theatre"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Movie"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Charity"
                },
            };

            return categories;
        }
    }
}
