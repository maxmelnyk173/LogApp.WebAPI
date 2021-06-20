using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogApp.Data
{
    public class LoginnedUserViewModel
    {
        public string Token { get; set; }

        public UserViewModel User { get; set; }
    }
}
