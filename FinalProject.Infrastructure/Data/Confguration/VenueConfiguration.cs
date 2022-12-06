using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data.Confguration
{
    public class VenueConfiguration: IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasData(SeedCategories());
        }

        public List<Venue> SeedCategories()
        {
            var venues = new List<Venue>()
            {
                new Venue()
                {
                    Id = Guid.Parse("b83b35c8-1c9d-4404-a7c9-a76cc9617719"),
                    Name = "Hale3",
                    ImageUrl="",
                    City = "Varna"
                },
                new Venue()
                {
                    Id = Guid.Parse("4611cec5-9233-4c0c-9201-529b9af6235d"),
                    Name = "Sofia Puppet Theatre",
                    ImageUrl="",
                    City = "Sofia"
                },
                new Venue()
                {
                    Id = Guid.Parse("b80248ba-4607-498e-bbd5-afd4f7221979"),
                    Name = "CinemaCity",
                    ImageUrl="",
                    City = "Plovdiv"
                },
                new Venue()
                {
                    Id = Guid.Parse("197ee165-a4da-46d7-893a-f1cefc6ddc96"),
                    Name = "Culture Home Burgas",
                    ImageUrl="",
                    City = "Burgas"
                },
            };

            return venues;
        }
    }
}
