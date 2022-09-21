using System.ComponentModel.DataAnnotations.Schema;

namespace fbay.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

    }
}
