using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Data
{
    public class User: IdentityUser
    {
        public List<UserEvent> UsersEvents { get; set; } = new List<UserEvent>();

        public List<UserTicket> UserTickets { get; set; } = new List<UserTicket>();
    }
}
