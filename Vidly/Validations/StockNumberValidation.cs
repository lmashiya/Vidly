using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Validations
{
    public class StockNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return movie.NumberOfStock > 0 
                ? ValidationResult.Success 
                : new ValidationResult("The field number in stock must be between 1 and 20.");
        }
    }
}