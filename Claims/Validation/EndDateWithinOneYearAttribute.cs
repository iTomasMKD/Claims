using Claims.Models;
using System.ComponentModel.DataAnnotations;

namespace Claims.Validation
{
    public class EndDateWithinOneYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime endDate = (DateTime)value;
            DateTime startDate = GetStartDate(validationContext.ObjectInstance);

            if (endDate >= startDate && endDate <= startDate.AddYears(1))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }

        private DateTime GetStartDate(object instance)
        {
            var claim = instance as Claim;
            if (claim != null)
            {
                var cover = GetCoverById(claim.CoverId);
                if (cover != null)
                {
                    return cover.StartDate;
                }
            }

            return DateTime.MinValue;
        }

        private Cover GetCoverById(string coverId)
        {
            // Replace this with your logic to retrieve the related Cover object by its Id
            // You can use this method to fetch the Cover object from a database or any other data source
            // Return the Cover object if found, or null if not found

            // Example implementation:
            // Assuming you have a list of covers stored in a variable called "covers"
            // You can iterate over the list and find the cover with the matching Id
            // Return the cover if found, or null if not found

            List<Cover> covers = new List<Cover>(); // Replace this with your actual list of covers

            foreach (var cover in covers)
            {
                if (cover.Id == coverId)
                {
                    return cover;
                }
            }

            return null;
        }
    }
}
