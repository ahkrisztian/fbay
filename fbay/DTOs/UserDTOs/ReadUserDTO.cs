using fbay.Models;
using System.ComponentModel.DataAnnotations;

namespace fbay.DTOs.UserDTOs
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        //DateTime UserCreatedOn { get; set; } 

        public List<ReadAddressDTO> Addresses { get; set; } = new List<ReadAddressDTO>();

        //public List<Advertisement> advertisements { get; set; } = new List<Advertisement>();
    }
}
