namespace fbay.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagTitle { get; set; }

        public int AdvertisementId { get; set; }
    }
}
