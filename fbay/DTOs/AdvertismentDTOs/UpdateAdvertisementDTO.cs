using fbay.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fbay.DTOs.AdvertismentDTOs
{
    public class UpdateAdvertisementDTO
    {
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateUpdated { get; set; } = DateTime.Now;

        public List<AddressToTakeDTO> addressToTakes { get; set; } = new List<AddressToTakeDTO>();
        public List<TagDTO> keywords { get; set; } = new List<TagDTO>();
        public List<ImageDTO> ImageUrls { get; set; } = new List<ImageDTO>();
    }
}
