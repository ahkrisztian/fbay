using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string PassWord { get; set; }
        public string PassWordHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UserCreatedOn  { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<Advertisement> advertisements { get; set; } = new List<Advertisement>();
    }
}
