using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string EventOrganiser { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        public int Likes { get; set; } = 0;

        public int Interested { get; set; } = 0;

        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public Guid? VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue Venue { get; set; } = null!;

        public List<UserEvent> UserEvents { get; set; } = new List<UserEvent>();
    }
}
