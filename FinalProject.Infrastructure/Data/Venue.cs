using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data
{
    public class Venue
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [StringLength(85)]
        public string City { get; set; } = null!;
    }
}
