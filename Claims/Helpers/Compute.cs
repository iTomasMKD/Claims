using Claims.Models;

namespace Claims.Helpers
{
    public static class Compute
    {
        //public static decimal ComputePremium(DateOnly startDate, DateOnly endDate, CoverType coverType)
        //{
        //    var multiplier = 1.3m;
        //    if (coverType == CoverType.Yacht)
        //    {
        //        multiplier = 1.1m;
        //    }

        //    if (coverType == CoverType.PassengerShip)
        //    {
        //        multiplier = 1.2m;
        //    }

        //    if (coverType == CoverType.Tanker)
        //    {
        //        multiplier = 1.5m;
        //    }

        //    var premiumPerDay = 1250 * multiplier;
        //    var insuranceLength = endDate.DayNumber - startDate.DayNumber;
        //    var totalPremium = 0m;

        //    for (var i = 0; i < insuranceLength; i++)
        //    {
        //        if (i < 30) totalPremium += premiumPerDay;
        //        if (i < 180 && coverType == CoverType.Yacht) totalPremium += premiumPerDay - premiumPerDay * 0.05m;
        //        else if (i < 180) totalPremium += premiumPerDay - premiumPerDay * 0.02m;
        //        if (i < 365 && coverType != CoverType.Yacht) totalPremium += premiumPerDay - premiumPerDay * 0.03m;
        //        else if (i < 365) totalPremium += premiumPerDay - premiumPerDay * 0.08m;
        //    }

        //    return totalPremium;
        //}

        public static decimal ComputePremium(DateOnly startDate, DateOnly endDate, CoverType coverType)
        {
            var multiplier = GetMultiplier(coverType);
            var premiumPerDay = 1250 * multiplier;
            var insuranceLength = endDate.DayNumber - startDate.DayNumber;

            var totalPremium = 0m;
            if (insuranceLength <= 30)
            {
                totalPremium = ComputePremiumForFirst30Days(insuranceLength, premiumPerDay);
            }
            else if (insuranceLength <= 180)
            {
                totalPremium = ComputePremiumForFirst30Days(30, premiumPerDay) +
                               ComputePremiumForNext150Days(insuranceLength - 30, premiumPerDay, coverType);
            }
            else
            {
                totalPremium = ComputePremiumForFirst30Days(30, premiumPerDay) +
                               ComputePremiumForNext150Days(150, premiumPerDay, coverType) +
                               ComputePremiumForRemainingDays(insuranceLength - 180, premiumPerDay, coverType);
            }

            return totalPremium;
        }

        private static decimal GetMultiplier(CoverType coverType)
        {
            switch (coverType)
            {
                case CoverType.Yacht:
                    return 1.1m;
                case CoverType.PassengerShip:
                    return 1.2m;
                case CoverType.Tanker:
                    return 1.5m;
                default:
                    return 1.3m;
            }
        }

        private static decimal ComputePremiumForFirst30Days(int days, decimal premiumPerDay)
        {
            return days * premiumPerDay;
        }

        private static decimal ComputePremiumForNext150Days(int days, decimal premiumPerDay, CoverType coverType)
        {
            var discount = coverType == CoverType.Yacht ? 0.05m : 0.02m;
            return days * (premiumPerDay - premiumPerDay * discount);
        }

        private static decimal ComputePremiumForRemainingDays(int days, decimal premiumPerDay, CoverType coverType)
        {
            var discount = coverType == CoverType.Yacht ? 0.08m : 0.03m;
            return days * (premiumPerDay - premiumPerDay * discount);
        }

    }
}
