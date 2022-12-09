using FinalProject.Core.Contracts;
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
        private Mock<ApplicationDbContext> asdasdl;

        [TestInitialize]
        public void Setup()
        {
           
        }

        [TestMethod]
        public async Task AddTicketToUser_Should_Add_Ticket_To_User_When_Valid_Info_Is_Provided()
        {
            string validUserId = "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c";
            Guid validTicketId = Guid.NewGuid();
            Guid validEventId = Guid.Parse("B9433DCC-175A-447C-BA1D-4C99BDB36232");

            Ticket validTicket = new Ticket()
            {
                Id = validTicketId,
                EventName = "Test",
                Date = new DateTime(),
                TicketHolder = "Me",
                TicketReference = "SomeReference",
                ImageUrl = "asdnadsnasdnadssd",
                Price = 5,
                EventId = validEventId,
            };

            var newUser = new User()
            {
                Id = "9544756e-d3c1-4965-bf8d-8eb7ecaabf9c",
                UserName = "guest1",
                NormalizedUserName = "guest1",
                Email = "guest1@gmail.com",
                NormalizedEmail = "GUEST1@GMAIL.COM"
            };
            
        }   
    }
}
