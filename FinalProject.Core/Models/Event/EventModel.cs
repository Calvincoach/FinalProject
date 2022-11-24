using FinalProject.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string EventOrganiser { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "2000.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Likes { get; set; }
        public int Interested { get; set; }

        [Required]
        [StringLength(6000)]
        public string Description { get; set; } = null!;

        public int? CategoryId { get; set; }

        public Guid? VenueId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public IEnumerable<Venue> Venues { get; set; } = new List<Venue>();
    }
}
