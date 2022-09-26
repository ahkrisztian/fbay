using fbay.Models;
using System.ComponentModel.DataAnnotations;

namespace fbay.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public List<UpdateAddressDTO> Addresses { get; set; } = new List<UpdateAddressDTO>();
    }
}
