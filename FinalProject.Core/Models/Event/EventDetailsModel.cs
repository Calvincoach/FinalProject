using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models.Event
{
    public class EventDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string EventOrganiser { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = null!;

        public int Likes { get; set; }

        public int Interested { get; set; }

        public string Category { get; set; } = null!;

        public string Venue { get; set; } = null!; 
    }
}
