﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DoggyRestApi.Models
{
    /// <summary>
    /// This class inherits the IdentityUser class for adding custom user columns
    /// </summary>
    public class ProjectIdentityUser : IdentityUser
    {
        public string? Address { get; set; }


        [Required]
        public ShoppingCart? ShoppingCart { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public virtual ICollection<IdentityUserRole<string>>? UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>>? Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>>? Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>>? Tokens { get; set; }
    }
}
