using FinalProject.Contracts;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services
{
    public class EventService:IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task AddMovieAsync(AddMovieViewModel model)
        //{
        //    var entity = new Movie()
        //    {
        //        Director = model.Director,
        //        GenreId = model.GenreId,
        //        ImageUrl = model.ImageUrl,
        //        Rating = model.Rating,
        //        Title = model.Title
        //    };

        //    await context.Movies.AddAsync(entity);
        //    await context.SaveChangesAsync();
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
