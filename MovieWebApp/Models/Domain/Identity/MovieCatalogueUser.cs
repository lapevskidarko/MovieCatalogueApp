using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApp.Models.Domain.Identity
{
    public class MovieCatalogueUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

       // public virtual MovieCart UserCart { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }

    }
}
