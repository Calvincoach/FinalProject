using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data
{
    public class UserTicket
    {
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public Guid TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }
    }
}
