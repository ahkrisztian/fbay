using fbay.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fbay.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public string PassWord { get; set; }
        public string PassWordHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UserCreatedOn { get; set; } = DateTime.UtcNow;

        public List<UpdateAddressDTO> Addresses { get; set; } = new List<UpdateAddressDTO>();
    }
}
