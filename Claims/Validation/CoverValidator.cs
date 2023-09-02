using Claims.Models;
using FluentValidation;

namespace Claims.Validation
{
 
public class CoverValidator : AbstractValidator<Cover>
    {
        //public CoverValidator()
        //{
        //    RuleFor(cover => cover.StartDate)
        //        .Must(BeValidStartDate)
        //        .WithMessage("Start Date cannot be in the past");

        //    RuleFor(cover => cover)
        //        .Must(HaveValidInsurancePeriod)
        //        .WithMessage("Total insurance period cannot exceed 1 year");
        //}

        //private bool BeValidStartDate(DateTime startDate)
        //{
        //    return startDate >= DateTime.Today;
        //}

        //private bool HaveValidInsurancePeriod(Cover cover)
        //{
        //    DateTime endDate = cover.StartDate.AddDays(365); // Assuming 1 year is considered as 365 days

        //    return endDate >= cover.StartDate && endDate <= cover.EndDate;
        //}
    }

}

