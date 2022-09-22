using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbay.Models
{
    public class Advertisement
    {
        public int Id   { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AddressToTakeOver { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateUpdated { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateDeleted { get; set; }
        public int UserId { get; set; }

        public string keywords { get; set; }
        public List<Image> ImageUrls { get; set; } = new List<Image>();


    }
}
