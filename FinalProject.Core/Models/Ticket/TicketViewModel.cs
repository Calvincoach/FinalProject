using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models.Ticket
{
    public class TicketViewModel
    {
        public Guid Id { get; set; }

        public string EventName { get; set; }

        public string TicketHolder { get; set; }

        public string TicketReference { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public Guid EventId { get; set; }
    }
}
