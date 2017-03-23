using asp.net_mvc_video_rental_store.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace asp.net_mvc_video_rental_store.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.DrivingLicence)
                .HasMaxLength(255)
                .IsRequired();

            Property(u => u.Phone)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}