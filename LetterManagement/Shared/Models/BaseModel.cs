﻿namespace LetterManagement.Shared.Models
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
