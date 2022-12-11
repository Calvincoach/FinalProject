using FinalProject.Contracts;
using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Event;
using FinalProject.Core.Models.Venue;
using FinalProject.Core.Services;
using FinalProject.Infrastructure.Data;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Tests.ServiceTests
{
    [TestClass]
    public class EventServiceTests
    {
        private IEventService? _sut;
        private ApplicationDbContext? _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "FinalProject")
                 .Options;
            _context = new ApplicationDbContext(options);
            _sut = new EventService(_context);
        }

        [TestMethod]
        public async Task AddEventAsync_Should_Add_Event_When_Valid_Model_Is_Passed()
        {
            var venue = CreateVenue();
            var modelToPass = CreatEventModel(venue);

            await _sut!.AddEventAsync(modelToPass);
            var actual = _context!.Events.Any();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task AddEventAsync_Should_Throw_Exception_When_Event_Already_Exists_With_Same_Id_And_VenueId()
        {
            var venue = CreateVenue();
            var modelToPass = CreatEventModel(venue);
            
            await _sut!.AddEventAsync(modelToPass);
            await _sut!.AddEventAsync(modelToPass);
        }

        [TestMethod]
        public async Task GetCategoriesAsync_Should_Return_IEnumerable_Of_Category()
        {
            var actual = await _sut!.GetCategoriesAsync();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Category>));
        }

        [TestMethod]
        public async Task GetVenuesAsync_Should_Return_IEnumerable_Of_Venue()
        {
            var actual = await _sut!.GetVenuesAsync();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Venue>));
        }

        [TestMethod]
        public async Task GetAllEventsAsync_Should_Return_IEnumerable_Of_EventViewModel()
        {
            var actual = await _sut!.GetAllEventsAsync();

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<EventViewModel>));
        }

        [TestMethod]
        public async Task GetEventAsync_Should_Return_Event()
        {
            var venue = CreateVenue();
            var model = CreatEventModel(venue);

            await _sut!.AddEventAsync(model);

            var eventToCheck = _context!.Events.First();

            var actual = await _sut!.GetEventAsync(eventToCheck.Id);

            Assert.IsInstanceOfType(actual, typeof(Event));
        }


        [TestMethod]
        public async Task FindEventAsync_Should_Return_True_When_Valid_EventId_Is_Passed()
        {
            var venue = CreateVenue();
            var model = CreatEventModel(venue);

            await _sut!.AddEventAsync(model);

            var eventToCheck = _context!.Events.First();

            var actual = await _sut!.FindEventAsync(eventToCheck.Id);

            Assert.IsTrue(actual);
        }


        [TestMethod]
        public async Task FindEventAsync_Should_Return_False_When_No_Such_Event_Exists()
        {
            var actual = await _sut!.FindEventAsync(Guid.NewGuid());

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public async Task DeleteEventAsync_Should_Delete_Event_When_Valid_Existing_Event_Is_Passed()
        {
            var venue = CreateVenue();
            var model = CreatEventModel(venue);

            await _sut!.AddEventAsync(model);

            var eventToCheck = _context!.Events.First();

            await _sut!.DeleteEventAsync(eventToCheck.Id);

            var actual = await _sut!.FindEventAsync(eventToCheck.Id);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task DeleteEventAsync_Should_Throw_Exception_When_Invalid_EventId_Is_Passed()
        {
            await _sut!.DeleteEventAsync(Guid.NewGuid());
        }

        [TestMethod]
        public async Task EditAsync_Should_Save_Edited_Event_With_The_Latest_Data()
        {
            var venue = CreateVenue();
            var model = CreatEventModel(venue);

            await _sut!.AddEventAsync(model);

            var oldEvent = _context!.Events.First();
            string oldName = oldEvent.Name;

            var editedModel = new EventModel()
            {
                Id = model.Id,
                Name = "NewName",
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Date = model.Date,
                Description = model.Description,
                CategoryId = model.CategoryId,
                VenueId = model.VenueId,
            };

            await _sut!.EditAsync(oldEvent.Id, editedModel);

            var updatedEventName = _context!.Events.First().Name;

            Assert.AreNotEqual(oldName, updatedEventName);
        }

        [TestMethod]
        public async Task EventDetailsAsync_ShouldReturn_EventDetailsModel_When_Valid_Event_Is_Passed()
        {
            var venue = CreateVenue();
            CreateCategory();
            var model = CreatEventModel(venue);

            await _sut!.AddEventAsync(model);

            var currentEvent = _context!.Events.First();

            var actual = await _sut!.EventDetailsAsync(currentEvent);

            Assert.IsInstanceOfType(actual, typeof(EventDetailsModel));
        }

        [TestMethod]
        public async Task AddEventToCollectionAsync_Should_Add_Existing_Event_To_Collection()
        {
            var user = CreateUser();
            var venue = CreateVenue();
            var model = CreatEventModel(venue);
            await _sut!.AddEventAsync(model);

            var existingEvent = _context!.Events.First();
            await _sut!.AddEventToCollectionAsync(existingEvent.Id, user.Id);

            var actual = user.UsersEvents.FirstOrDefault(x => x.EventId == existingEvent.Id && x.UserId == user.Id);

            Assert.IsNotNull(actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid user ID")]
        public async Task AddEventToCollectionAsync_Should_Throw_Error_When_User_Is_Invalid()
        {
            await _sut!.AddEventToCollectionAsync(Guid.NewGuid(), "someid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid event ID")]
        public async Task AddEventToCollectionAsync_Should_Throw_Error_When_Event_Is_Invalid()
        {
            var user = CreateUser();
            var venue = CreateVenue();
            var model = CreatEventModel(venue);
            await _sut!.AddEventAsync(model);

            await _sut!.AddEventToCollectionAsync(Guid.NewGuid(), user.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid user ID")]
        public async Task GetInterestedEventsAsync_Should_Throw_Exception_When_Invalid_User_Is_Passed()
        {
            await _sut!.GetInterestedEventsAsync("someString");
        }

        [TestMethod]
        public async Task GetInterestedEventsAsync_Should_Return_IEnumerable_Of_EventViewModel_When_VValid_User_Is_Passed()
        {
            var user = CreateUser();
            var venue = CreateVenue();
            var model = CreatEventModel(venue);
            await _sut!.AddEventAsync(model);

            var actual = await _sut!.GetInterestedEventsAsync(user.Id);

            Assert.IsInstanceOfType(actual, typeof(IEnumerable<EventViewModel>));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid user ID")]
        public async Task RemoveInterestedEventsAsync_Should_Throw_Exception_When_User_Is_Invalid()
        {
            await _sut!.RemoveInterestedEventsAsync(Guid.NewGuid(), "sdasdasd");
        }

        [TestMethod]
        public async Task RemoveInterestedEventsAsync_Should_Remove_Event_From_Collection()
        {
            var user = CreateUser();

            var newEvent = new Event()
            {
                Id = Guid.NewGuid(),
                EventOrganiser = "asdas",
                Description = "asdas",
                ImageUrl = "asdas",
                Date = new DateTime(),
                Price = 5.5M,
                Name = "asdas",
                CategoryId = 1,
                VenueId = Guid.NewGuid()
            };

            _context!.Events.Add(newEvent);

            user.UsersEvents.Add(new UserEvent()
            {
                EventId = newEvent.Id,
                UserId = user.Id,
                Event = newEvent,
                User = user
            });

            await _sut!.RemoveInterestedEventsAsync(newEvent.Id, user.Id);

            var actual = user.UsersEvents.Any();

            Assert.IsFalse(actual);
        }

        public EventModel CreatEventModel(Venue venue)
        {
            var model = new EventModel()
            {
                Id = Guid.NewGuid(),
                Name = "name",
                EventOrganiser = "organiser",
                ImageUrl = "imgurl",
                Price = 5.5M,
                Date = new DateTime(),
                Description = "desc",
                Interested = 0,
                CategoryId = 1,
                VenueId = venue.Id,
                Categories = new List<Category>(),
                Venues = new List<Venue>()
            };
            return model;
        }

        public Venue CreateVenue()
        {
            var venue = new Venue()
            {
                Id = Guid.NewGuid(),
                City = "somecity",
                Name = "somename",
                ImageUrl = "sdasads"
            };

            _context!.Venues.Add(venue);
            _context.SaveChanges();
        return venue;
        }

        public void CreateCategory()
        {
            var category = new Category()
            {
                Id = 1,
                Name = "testCategory"
            };

            _context!.Categories.Add(category);
            _context.SaveChanges();
        }

        public User CreateUser()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "guest1",
                NormalizedUserName = "guest1",
                Email = "guest1@gmail.com",
                NormalizedEmail = "GUEST1@GMAIL.COM"
            };

            _context!.Users.Add(newUser);
            _context!.SaveChanges();
            return newUser;
        }
    }
}
