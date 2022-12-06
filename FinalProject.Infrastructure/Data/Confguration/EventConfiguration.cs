using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data.Confguration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(SeedEvents());
        }

        public List<Event> SeedEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sunami Live Concert",
                    EventOrganiser = "REAL BAY SH*T",
                    ImageUrl = "https://f4.bcbits.com/img/a0705911045_10.jpg",
                    Price = 20,
                    Date = DateTime.Now,
                    Description = "Sunami EP promo live, be there. ",
                    Interested = 0,
                    CategoryId = 1,
                    VenueId = Guid.Parse("b83b35c8-1c9d-4404-a7c9-a76cc9617719"),
                },
                new Event()
                {
                    Id = Guid.NewGuid(),
                    Name = "The frog king",
                    EventOrganiser = "Sofia Theatre",
                    ImageUrl = "http://theatre.art.bg/img/photos/BIG14008272141zabokyt%20(1).jpg",
                    Price = 10,
                    Date = DateTime.Now,
                    Description = "The puppets show is in town, bring your kids for a fun spectacle.",
                    Interested = 0,
                    CategoryId = 2,
                    VenueId = Guid.Parse("4611cec5-9233-4c0c-9201-529b9af6235d"),
                },
                new Event()
                {
                    Id = Guid.NewGuid(),
                    Name = "The Batman (2022) Premiere",
                    EventOrganiser = "Matt Reeves",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg",
                    Price = 12,
                    Date = DateTime.Now,
                    Description = "The premiere of the new Batman coming to this fall.",
                    Interested = 0,
                    CategoryId = 3,
                    VenueId = Guid.Parse("b80248ba-4607-498e-bbd5-afd4f7221979"),
                },
                new Event()
                {
                    Id = Guid.NewGuid(),
                    Name = "Charity",
                    EventOrganiser = "JPMorgan",
                    ImageUrl = "https://mma.prnewswire.com/media/444000/Make_A_Wish_Logo.jpg?p=twitter",
                    Price = 0,
                    Date = DateTime.Now,
                    Description = "This is a charity even for the Make-a-wish foundation hosted by JPMorgan.",
                    Interested = 0,
                    CategoryId = 4,
                    VenueId = Guid.Parse("197ee165-a4da-46d7-893a-f1cefc6ddc96"),
                }
            };

            return events;
        }
    }
}
