using fbay.Data;
using fbay.Models;

namespace fbay.Services
{
    public class AdvertisementRepo : IAdvertisementRepo
    {
        private readonly AppDbContext _context;

        public AdvertisementRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAdvertisement(Advertisement adv)
        {
            if (adv == null)
            {
                throw new ArgumentNullException(nameof(adv));
            }

            using (_context)
            {
                await _context.Advertisements.AddAsync(adv);
                await _context.SaveChangesAsync();
            }
        }


        public Task DeleteAdvertisement(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Advertisement>> GetAdvertisementByAdvertiser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisement> GetAdvertisementByKeyWords(int id, string size, string[] keywords)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Advertisement>> GetAdvertisementByUserrId(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdvertisement(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
    }
}
