using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

namespace IrvingParkContactList.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<CityBlock> CityBlocks { get; set; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}