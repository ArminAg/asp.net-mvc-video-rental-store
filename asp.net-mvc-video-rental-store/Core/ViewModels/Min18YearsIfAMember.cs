using asp.net_mvc_video_rental_store.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerViewModel)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : 
                new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}