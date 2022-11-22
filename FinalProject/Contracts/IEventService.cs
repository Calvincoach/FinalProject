using FinalProject.Core.Models.Event;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;

namespace FinalProject.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        Task AddEventAsync(AddEventViewModel model);

        Task<IEnumerable<Venue>> GetVenuesAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();

        //Task AddMovieToCollectionAsync(int movieId, string userId);

        //Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId);

        //Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
