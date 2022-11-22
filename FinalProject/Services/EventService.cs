using FinalProject.Contracts;
using FinalProject.Core.Models.Event;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalProject.Services
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEventAsync(AddEventViewModel model)
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


        //public async Task<IEnumerable<Genre>> GetGenresAsync()
        //{
        //    return await context.Genres.ToListAsync();
        //}

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
    }
}
