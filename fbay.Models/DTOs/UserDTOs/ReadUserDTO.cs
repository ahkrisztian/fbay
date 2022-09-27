

namespace fbayModels.DTOs.UserDTOs
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        //DateTime UserCreatedOn { get; set; } 

        public List<ReadAddressDTO> Addresses { get; set; } = new List<ReadAddressDTO>();

        //public List<Advertisement> advertisements { get; set; } = new List<Advertisement>();
    }
}
