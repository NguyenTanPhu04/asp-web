﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace projectA.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
    }
}
