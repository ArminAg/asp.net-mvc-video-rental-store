using asp.net_mvc_video_rental_store.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace asp.net_mvc_video_rental_store.Persistence.EntityConfigurations
{
    public class MembershipTypeConfiguration : EntityTypeConfiguration<MembershipType>
    {
        public MembershipTypeConfiguration()
        {
            Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}