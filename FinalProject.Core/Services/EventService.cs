using FinalProject.Contracts;
using FinalProject.Core.Models.Event;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace FinalProject.Services
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(EventModel model)
        {
            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Date == model.Date && e.VenueId == model.VenueId);
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == model.VenueId);
            if (existingEvent is not null)
            {
                throw new Exception($"An event already exists for {model.Date} at {venue.Name}");
            }
            var eventEntity = new Event()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                EventOrganiser = model.EventOrganiser,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Date = model.Date,
                Description = model.Description,
                CategoryId = model.CategoryId,
                VenueId = model.VenueId
            };

            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Venue>> GetVenuesAsync()
        {
            return await _context.Venues.ToListAsync();
        }


        public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
        {
            var events = await _context.Events
                .Include(e => e.Category)
                .ToListAsync();

            return events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    EventOrganiser = e.EventOrganiser,
                    ImageUrl = e.ImageUrl,
                    Likes = e.Likes,
                    Category = e?.Category?.Name
                });
        }

        public async Task DeleteEventAsync(Guid eventId)
        {
            var dbEvent = await _context.Events.FindAsync(eventId);
            if (dbEvent is null)
            {
                throw new Exception($"Something went wrong!");
            }
            _context.Events.Remove(dbEvent);
            _context.SaveChanges();
        }

        public async Task<Event> GetEventAsync(Guid eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<bool> FindEventAsync(Guid eventId)
        {
            return await _context.Events.FindAsync(eventId) is null ? false : true ;
        }

        public async Task Edit(Guid eventId, EventModel model)
        {
            var entity = await GetEventAsync(eventId);

            entity.Name = model.Name;
            entity.EventOrganiser = model.EventOrganiser;
            entity.ImageUrl = model.ImageUrl;
            entity.Price = model.Price;
            entity.Date = model.Date;
            entity.Description = model.Description;
            entity.CategoryId = model.CategoryId;
            entity.VenueId = model.VenueId;

            await _context.SaveChangesAsync();
        }

        public async Task<EventDetailsModel> EventDetails(Event currentEvent)
        {

            var eventCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == currentEvent.CategoryId);
            var eventVenue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == currentEvent.VenueId);

            var model = new EventDetailsModel()
            {
                Id = currentEvent.Id,
                Name = currentEvent.Name,
                EventOrganiser = currentEvent.EventOrganiser,
                ImageUrl = currentEvent.ImageUrl,
                Price = currentEvent.Price,
                Date = currentEvent.Date,
                Description = currentEvent.Description,
                Likes = currentEvent.Likes,
                Interested = currentEvent.Interested,
                Category = eventCategory.Name,
                Venue = eventVenue.Name,
            };

            return model;
        }
        //public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .ThenInclude(um => um.Movie)
        //        .ThenInclude(m => m.Genre)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    return user.UsersMovies
        //        .Select(m => new MovieViewModel()
        //        {
        //            Director = m.Movie.Director,
        //            Genre = m.Movie.Genre?.Name,
        //            Id = m.MovieId,
        //            ImageUrl = m.Movie.ImageUrl,
        //            Title = m.Movie.Title,
        //            Rating = m.Movie.Rating,
        //        });
        //}

        //public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

        //    if (movie != null)
        //    {
        //        user.UsersMovies.Remove(movie);

        //        await context.SaveChangesAsync();
        //    }
        //}

        //public async Task AddMovieToCollectionAsync(int movieId, string userId)
        //{
        //    var user = await context.Users
        //        .Where(u => u.Id == userId)
        //        .Include(u => u.UsersMovies)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        throw new ArgumentException("Invalid user ID");
        //    }

        //    var movie = await context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);

        //    if (movie == null)
        //    {
        //        throw new ArgumentException("Invalid Movie ID");
        //    }

        //    if (!user.UsersMovies.Any(m => m.MovieId == movieId))
        //    {
        //        user.UsersMovies.Add(new UserMovie()
        //        {
        //            MovieId = movie.Id,
        //            UserId = user.Id,
        //            Movie = movie,
        //            User = user
        //        });

        //        await context.SaveChangesAsync();
        //    }
        //}
    }
}
