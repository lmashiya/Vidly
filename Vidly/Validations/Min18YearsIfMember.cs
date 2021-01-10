﻿using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Validations
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if(customer.DateOfBirth == null) return new ValidationResult("BirthDate is required");
            
            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer should be 18 years old old to go on membership.");
        }
    }
}