using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Venue;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public class VenueService : IVenueService
    {
        private readonly ApplicationDbContext _context;

        public VenueService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VenueViewModel>> GetAllVenues()
        {
            var venues = await _context.Venues.ToListAsync();

            return venues
                .Select(v => new VenueViewModel()
                {
                    Id = v.Id,
                    Name = v.Name,
                    ImageUrl = v.ImageUrl,
                    City = v.City
                });
        }
    }
}
