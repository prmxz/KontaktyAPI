﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KontaktyAPI.Models
{
    public class UpdateContactDTO               //Data Transfer Object(DTO) for modifying existing Contacs table content
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
    }
}
