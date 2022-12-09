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
                    Interested = e.Interested,
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

        public async Task EditAsync(Guid eventId, EventModel model)
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

        public async Task<EventDetailsModel> EventDetailsAsync(Event currentEvent)
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
                Interested = currentEvent.Interested,
                Category = eventCategory.Name,
                Venue = eventVenue.Name
            };

            return model;
        }

        public async Task AddEventToCollectionAsync(Guid eventId, string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersEvents)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);

            if (existingEvent == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!user.UsersEvents.Any(e => e.EventId == eventId))
            {
                existingEvent.Interested++;

                user.UsersEvents.Add(new UserEvent()
                {
                    EventId = existingEvent.Id,
                    UserId = user.Id,
                    Event = existingEvent,
                    User = user
                });
                

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventViewModel>> GetInterestedEventsAsync(string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersEvents)
                .ThenInclude(ue => ue.Event)
                .ThenInclude(e => e.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersEvents
                .Select(e => new EventViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    EventOrganiser = e.Event.EventOrganiser,
                    ImageUrl = e.Event.ImageUrl,
                    Interested = e.Event.Interested,
                    Category = e?.Event.Category?.Name
                });
        }

        public async Task RemoveInterestedEventsAsync(Guid eventId, string userId)
        {
            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersEvents)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var existingEvent = user.UsersEvents.FirstOrDefault(e => e.EventId == eventId);

            if (existingEvent != null)
            {
                user.UsersEvents.Remove(existingEvent);

                await _context.SaveChangesAsync();
            }
        }
    }
}
