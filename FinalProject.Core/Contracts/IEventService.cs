using FinalProject.Core.Models.Event;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;

namespace FinalProject.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        Task AddEventAsync(EventModel model);

        Task<IEnumerable<Venue>> GetVenuesAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task DeleteEventAsync(Guid eventId);

        Task<bool> FindEventAsync(Guid eventId);

        Task<Event> GetEventAsync(Guid eventId);

        Task Edit(Guid eventId, EventModel model);

        Task<EventDetailsModel> EventDetails(Event currentEvent);

        Task AddEventToCollectionAsync(Guid eventId, string userId);

        Task<IEnumerable<EventViewModel>> GetInterestedEventsAsync(string userId);

        Task RemoveInterestedEventsAsync(Guid eventId, string userId);
    }
}
