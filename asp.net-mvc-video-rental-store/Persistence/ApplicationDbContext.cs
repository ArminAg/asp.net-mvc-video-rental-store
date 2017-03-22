using asp.net_mvc_video_rental_store.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace asp.net_mvc_video_rental_store.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
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