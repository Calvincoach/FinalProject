using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Ticket;
using FinalProject.Core.Models.Venue;
using FinalProject.Core.Services;
using FinalProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Tests.ServiceTests
{
    [TestClass]
    public class TicketServiceTests
    {
        private ITicketService? _sut;
        private ApplicationDbContext? _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "FinalProject")
                 .Options;
            _context = new ApplicationDbContext(options);
            _sut = new TicketService(_context);
        }

        [TestMethod]
        public async Task AddTicketToUser_Should_Add_Ticket_To_User_When_Valid_Info_Is_Provided()
        {
            var validTicket = CreateTicket();

            var newUser = CreateUser();

            _context!.SaveChanges();

            await _sut!.AddTicketToUserAsync(newUser.Id, validTicket);

            var actual = newUser.UserTickets.Where(x => x.TicketId == validTicket.Id && x.UserId == newUser.Id);
            Assert.IsTrue(actual.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Invalid user ID")]
        public async Task AddTicketToUser_Should_Throw_ArgumentException_When_User_Is_Null()
        {
            await _sut!.AddTicketToUserAsync("someid", new Ticket());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Invalid user ID")]
        public async Task GetUserTicketsAsync_Should_Throw_ArgumentException_When_User_Is_Null()
        {
            await _sut!.GetUserTicketsAsync("someid");
        }

        [TestMethod]
        public async Task GetUserTicketsAsync_Should_Return_Collection_Of_TicketViewModel_With_Same_Count_As_Venues()
        {
            var newUser = CreateUser();

            _context!.SaveChanges();

            var result = await _sut!.GetUserTicketsAsync(newUser.Id);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<TicketViewModel>));
        }

        [TestMethod]
        public async Task GetUserTicketsAsync_Should_Return_All_Tickets_For_User()
        {
            var validTicket = CreateTicket();

            var newUser = CreateUser();

            _context!.SaveChanges();

            await _sut!.AddTicketToUserAsync(newUser.Id, validTicket);

            var actual = await _sut.GetUserTicketsAsync(newUser.Id);

            Assert.IsTrue(actual.Any());
        }

        [TestMethod]
        public async Task ReserveTicketAsync_Should_Create_New_Ticket_When_Valid_Data_Is_Passed()
        {
            var modelToPass = new TicketModel()
            {
                Id = Guid.NewGuid(),
                EventName = "Test name",
                TicketHolder = "",
                TicketReference = $"reference",
                ImageUrl = "image",
                Date = new DateTime(),
                Price = 5.5M
            };

            string userId = CreateUser().Id;

            Guid eventId = CreateEvent().Id;

            _context!.SaveChanges();

            await _sut!.ReserveTicketAsync(modelToPass, userId, eventId);

            var actual = _context.Tickets.FirstOrDefault(x => x.Id == modelToPass.Id);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "Event doesn't exist")]
        public async Task ReserveTicketAsync_Should_Throw_Exception_When_Event_Is_Null()
        {
            await _sut!.ReserveTicketAsync(new TicketModel(), "someid", Guid.NewGuid());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
        "A ticket with ticket holder: Momchil already exists")]
        public async Task ReserveTicketAsync_Should_Throw_Exception_When_Ticket_Is_Null()
        {
            CreateEvent();

            Guid existingEventId = CreateTicket().EventId;

            var modelToPass = new TicketModel()
            {
                Id = Guid.NewGuid(),
                EventName = "Test name",
                TicketHolder = "Momchil",
                TicketReference = $"reference",
                ImageUrl = "image",
                Date = new DateTime(),
                Price = 5.5M
            };

            _context!.SaveChanges();

            await _sut!.ReserveTicketAsync(modelToPass, "someid", existingEventId);
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
            return newUser;
        }

        public Ticket CreateTicket()
        {
            Ticket validTicket = new Ticket()
            {
                Id = Guid.NewGuid(),
                EventName = "Test",
                Date = new DateTime(),
                TicketHolder = "Momchil",
                TicketReference = "SomeReference",
                ImageUrl = "asdnadsnasdnadssd",
                Price = 5,
                EventId = Guid.NewGuid(),
            };

            _context!.Tickets.Add(validTicket);

            return validTicket;
        }

        public Event CreateEvent()
        {
            Event validEvent = new Event()
            {
                Id = Guid.NewGuid(),
                Name = "eventName",
                EventOrganiser = "eventoOrganiser",
                ImageUrl = "eventImageUrl",
                Price = 5.5M,
                Date = new DateTime(),
                Description = "eventDesc",
                CategoryId = 2,
                VenueId = Guid.NewGuid()
            };

            _context!.Events.Add(validEvent);
            return validEvent;
        }
    }
}
