
namespace fbayModels.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public string PassWord { get; set; }
        public string PassWordHash { get; set; }
        public DateTime UserCreatedOn { get; set; } = DateTime.UtcNow;

        public List<UpdateAddressDTO> Addresses { get; set; } = new List<UpdateAddressDTO>();
    }
}
