
namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class CreateAdvertisementDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public List<AddressToTakeDTO> addressToTakes { get; set; } = new List<AddressToTakeDTO>();
        public List<TagDTO> keywords { get; set; } = new List<TagDTO>();
        public List<ImageDTO> ImageUrls { get; set; } = new List<ImageDTO>();
    }
}
