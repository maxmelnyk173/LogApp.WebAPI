﻿using System.ComponentModel.DataAnnotations;

namespace LogApp.Data
{
    public class UserVm
    {
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
