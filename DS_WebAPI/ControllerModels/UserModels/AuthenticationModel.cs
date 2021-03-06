﻿using System.ComponentModel.DataAnnotations;

namespace DS_WebAPI.ControllerModels.UserModels
{
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
