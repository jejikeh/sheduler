﻿using System.ComponentModel.DataAnnotations;

namespace Sheduler.Identity.Models;

public class LoginViewModel
{
    [Required] 
    public string Username { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public string ReturnUrl { get; set; } = string.Empty;
}