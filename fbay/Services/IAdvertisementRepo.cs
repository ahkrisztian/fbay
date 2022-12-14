using fbay.Models;

namespace fbay.Services
{
    public interface IAdvertisementRepo
    {
        Task<Advertisement> GetAdvertisementById(int id);
        Task<Advertisement> GetAdvertisementByKeyWords(int id, string size, string[] keywords);

        Task<IEnumerable<Advertisement>> GetAllAdvs();

        Task<IEnumerable<Advertisement>> GetAdvertisementByUserrId(int id);
        Task CreateAdvertisement(Advertisement advertisement);
        Task UpdateAdvertisement();
        Task DeleteAdvertisement(Advertisement advertisement);
    }
}
