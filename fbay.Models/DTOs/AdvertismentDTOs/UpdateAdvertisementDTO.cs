
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class UpdateAdvertisementDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? DateUpdated { get; set; } = DateTime.Now;

        public AddressToTakeDTO addressToTakes { get; set; }
        public List<TagDTO> keywords { get; set; } = new List<TagDTO>();
        public List<ImageDTO> ImageUrls { get; set; } = new List<ImageDTO>();
    }
}
