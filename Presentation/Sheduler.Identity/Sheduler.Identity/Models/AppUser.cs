﻿using Microsoft.AspNetCore.Identity;

namespace Sheduler.Identity.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}