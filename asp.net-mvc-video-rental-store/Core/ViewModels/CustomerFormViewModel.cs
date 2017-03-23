using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class CustomerFormViewModel
    {
        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Customer" : "Create Customer";
            }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipTypeViewModel> MembershipTypes { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }
    }
}