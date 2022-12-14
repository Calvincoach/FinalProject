using FinalProject.Core.Contracts;
using FinalProject.Core.Models.Venue;
using FinalProject.Core.Services;
using FinalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FinalProject.Tests.ServiceTests
{
    [TestClass]
    public class VenueServiceTest
    {
        private IVenueService? _sut;
        private ApplicationDbContext? _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "FinalProject")
                .Options;
            _context = new ApplicationDbContext(options);
            _sut = new VenueService(_context); 
        }


        [TestMethod]
        public async Task GetAllVenues_Should_Return_Collection_Of_VenueViewModel_With_Same_Count_As_Venues()
        {

            var result = await _sut!.GetAllVenues();

            Assert.IsInstanceOfType(result, typeof(IEnumerable<VenueViewModel>));
        }
    }
}
