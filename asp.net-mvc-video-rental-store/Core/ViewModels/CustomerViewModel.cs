using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeViewModel MembershipType { get; set; }
    }
}