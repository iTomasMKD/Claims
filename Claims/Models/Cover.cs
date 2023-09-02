using Claims.Validation;
using Newtonsoft.Json;

namespace Claims.Models
{
    public class Cover
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        [StartDateNotInPast(ErrorMessage = "StartDate cannot be in the past.")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        [EndDateWithinOneYear(ErrorMessage = "Total insurance period cannot exceed 1 year.")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "claimType")]
        public CoverType Type { get; set; }

        [JsonProperty(PropertyName = "premium")]
        public decimal Premium { get; set; }
    }
    public enum CoverType
    {
        Yacht = 0,
        PassengerShip = 1,
        ContainerShip = 2,
        BulkCarrier = 3,
        Tanker = 4
    }
}
