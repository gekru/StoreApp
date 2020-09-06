using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities.Base;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Represent if user allowed to use this resource
        /// </summary>
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ApplicationUser()
        {
            IsActive = true;
        }
    }
}
