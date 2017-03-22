using System;

namespace asp.net_mvc_video_rental_store.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public DateTime? BirthDate { get; set; }

        // Navigation Properties
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}