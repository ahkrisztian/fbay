using System.ComponentModel.DataAnnotations;

namespace fbayModels.DTOs.AdvertismentDTOs
{
    public class TagDTO
    {
        [Required]
        public string TagTitle { get; set; }
    }
}
