﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
