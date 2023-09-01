using Claims.Models;
using FluentValidation;

namespace Claims.Validation
{
    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator()
        {
            RuleFor(claim => claim.DamageCost)
                .LessThanOrEqualTo(100000)
                .WithMessage("Damage cost cannot exceed 100,000");

            RuleFor(claim => claim.Created)
                .Must((claim, created) => IsWithinCoverPeriod(claim.CoverId, created))
                .WithMessage("Created date must be within the period of the related Cover");
        }

        private object RuleFor(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        private bool IsWithinCoverPeriod(string coverId, DateTime created)
        {
            // Logic for getting Cover goes here.
            // Example:
            // Cover cover = _coverRepository.GetCover(coverId);

            //return created >= cover.StartDate && created <= cover.EndDate;
            return true;
        }
    }
}
