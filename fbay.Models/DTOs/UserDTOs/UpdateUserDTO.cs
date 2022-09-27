
namespace fbayModels.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public List<UpdateAddressDTO> Addresses { get; set; } = new List<UpdateAddressDTO>();
    }
}
