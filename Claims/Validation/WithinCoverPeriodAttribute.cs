using Claims.Models;
using System.ComponentModel.DataAnnotations;

namespace Claims.Validation
{
    public class WithinCoverPeriodAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var claim = (Claim)validationContext.ObjectInstance;
            var cover = GetCoverById(claim.CoverId);

            if (cover != null && claim.Created >= cover.StartDate && claim.Created <= cover.EndDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
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
