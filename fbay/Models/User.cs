using System.ComponentModel.DataAnnotations;

namespace fbay.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName  { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }   
        DateTime UserCreatedOn  { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Advertisement> advertisements { get; set; } = new List<Advertisement>();
    }
}
