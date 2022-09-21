using fbay.Models;

namespace fbay.Services
{
    public interface IAdvertisementRepo
    {
        Task<IEnumerable<Advertisement>> GetAdvertisementByAdvertiser(User user);
        Task<Advertisement> GetAdvertisementByKeyWords(int id, string size, string[] keywords);

        Task<IEnumerable<Advertisement>> GetAdvertisementByUserrId(int id);
        Task CreateAdvertisement(Advertisement advertisement);
        Task UpdateAdvertisement(Advertisement advertisement);
        Task DeleteAdvertisement(Advertisement advertisement);
    }
}
