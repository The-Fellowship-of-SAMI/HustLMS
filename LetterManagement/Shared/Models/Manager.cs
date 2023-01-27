﻿using System.ComponentModel.DataAnnotations;

namespace LetterManagement.Shared.Models
{
    public class Manager
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress] public string? Email { get; set; } 

        public string PhoneNumber { get; set; } = "";

        public Department? Department { get; set; } 
    }
}