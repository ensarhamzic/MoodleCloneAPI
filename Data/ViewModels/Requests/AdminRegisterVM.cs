﻿using System.ComponentModel.DataAnnotations;

namespace MoodleCloneAPI.Data.ViewModels.Requests
{
    public class AdminRegisterVM : UserRegisterVM
    {
        [Required]
        public bool Superadmin { get; set; }
    }
}