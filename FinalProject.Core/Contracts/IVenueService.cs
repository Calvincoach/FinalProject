using FinalProject.Core.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Contracts
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueViewModel>> GetAllVenues();
    }
}
