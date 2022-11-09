using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<UserTicket> UserTickets { get; set; } = new List<UserTicket>();
    }
}
