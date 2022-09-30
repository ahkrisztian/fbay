using System.ComponentModel.DataAnnotations;

namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class AddressToTakeDTO
    {
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
