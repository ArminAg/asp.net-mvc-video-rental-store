using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace asp.net_mvc_video_rental_store.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}