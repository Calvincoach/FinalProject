using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models.Ticket
{
    public class TicketModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string EventName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TicketHolder { get; set; }

        [Required]
        public string TicketReference { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "2000.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
    }
}
