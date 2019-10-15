using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BookWorld.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var member = (Member)validationContext.ObjectInstance;

            if(member.MembershipTypeId == MembershipType.Unknown ||
               member.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if(member.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - member.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You need to be at least 18 years old to be subscribed.");
        }
    }
}