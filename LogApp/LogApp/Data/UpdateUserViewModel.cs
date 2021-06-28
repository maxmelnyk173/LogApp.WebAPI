using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogApp.Data
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
