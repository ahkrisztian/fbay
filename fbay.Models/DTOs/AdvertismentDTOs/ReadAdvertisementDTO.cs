
namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class ReadAdvertisementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //public AddressToTakeDTO AddressToTakeOver { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<TagDTO> keywords { get; set; } = new List<TagDTO>();
        public List<ImageDTO> ImageUrls { get; set; } = new List<ImageDTO>();

        public List<AddressToTakeDTO> addressToTakes { get; set; } = new List<AddressToTakeDTO>();
    }
}
