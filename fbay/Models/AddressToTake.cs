﻿namespace fbay.Models
{
    public class AddressToTake
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int AdvertisementId { get; set; }
    }
}
