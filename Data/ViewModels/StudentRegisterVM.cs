﻿using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels
{
    public class StudentRegisterVM : UserRegisterVM
    {
        [Required]
        public string Adresa { get; set; } 
    }
}
