﻿using Microsoft.AspNetCore.Identity;

namespace ShopFlickerAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
