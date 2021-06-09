using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogApp.Data
{
    public class LoginnedUserViewModel
    {
        public string Token { get; set; }

        public DateTime ExpireAt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }
    }
}
