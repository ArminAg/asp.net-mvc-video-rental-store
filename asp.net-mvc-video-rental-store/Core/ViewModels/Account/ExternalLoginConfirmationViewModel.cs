﻿using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Driving Licence")]
        public string DrivingLicence { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}