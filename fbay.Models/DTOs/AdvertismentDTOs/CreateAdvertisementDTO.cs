using System.ComponentModel.DataAnnotations;

namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class CreateAdvertisementDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;
        [Required]
        public int UserId { get; set; }

        [Required]
        [ValidateComplexType]
        public List<AddressToTakeDTO> addressToTakes { get; set; } = new List<AddressToTakeDTO>();
        [Required]
        public List<TagDTO> keywords { get; set; } = new List<TagDTO>();
        [Required]
        public List<ImageDTO> ImageUrls { get; set; } = new List<ImageDTO>();
    }
}
