using System;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public MembershipTypeViewModel MembershipType { get; set; }
    }
}