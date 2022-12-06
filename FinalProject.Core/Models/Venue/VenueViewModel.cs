using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models.Venue
{
    public class VenueViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string City { get; set; }
    }
}
