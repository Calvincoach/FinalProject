using FinalProject.Infrastructure.Data;
using FinalProject.Models;

namespace FinalProject.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        //Task<IEnumerable<Category>> GetGenresAsync();

        //Task AddMovieAsync(AddMovieViewModel model);

        //Task AddMovieToCollectionAsync(int movieId, string userId);

        //Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        //Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
