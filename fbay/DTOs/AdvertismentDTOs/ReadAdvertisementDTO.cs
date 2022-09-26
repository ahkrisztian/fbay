using fbay.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fbay.DTOs.AdvertismentDTOs
{
    public class ReadAdvertisementDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public AddressToTake AddressToTakeOver { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateUpdated { get; set; }
        public List<Tag> keywords { get; set; } = new List<Tag>();
        public List<Image> ImageUrls { get; set; } = new List<Image>();

        public List<AddressToTake> addressToTakes { get; set; } = new List<AddressToTake>();
    }
}
