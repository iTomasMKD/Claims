using Claims.Validation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Claims.Models
{
    public class Claim
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "coverId")]
        public string CoverId { get; set; }

        [JsonProperty(PropertyName = "created")]
        [Required(ErrorMessage = "Created date is required.")]
        [WithinCoverPeriod(ErrorMessage = "Created date must be within the period of the related Cover.")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "claimType")]
        public ClaimType Type { get; set; }

        [JsonProperty(PropertyName = "damageCost")]
        [Range(0, 100000, ErrorMessage = "DamageCost cannot exceed 100,000.")]
        public decimal DamageCost { get; set; }
    }
    public enum ClaimType
    {
        Collision = 0,
        Grounding = 1,
        BadWeather = 2,
        Fire = 3
    }
}
