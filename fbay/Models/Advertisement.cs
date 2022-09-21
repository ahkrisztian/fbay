using System.ComponentModel.DataAnnotations;

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
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        DateTime DateDeleted { get; set; }
        public int UserId { get; set; }

        List<string> keywords { get; set; } = new List<string>();
        List<Image> ImageUrls { get; set; } = new List<Image>();


    }
}
