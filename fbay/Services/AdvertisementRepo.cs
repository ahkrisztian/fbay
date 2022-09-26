using fbay.Data;
using fbay.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Advertisement> GetAdvertisementById(int id)
        {
            return await _context.Advertisements
                .Include(address => address.addressToTakes)
                .Include(img => img.ImageUrls)
                .Include(keys => keys.keywords)
                .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<Advertisement> GetAdvertisementByKeyWords(int id, string size, string[] keywords)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Advertisement>> GetAdvertisementByUserrId(int id)
        {
            var advs = await _context.Users
                .Include(advs => advs.advertisements)
                .Where(u => u.Id == id).FirstOrDefaultAsync();

            return advs.advertisements;
        }

        public Task UpdateAdvertisement(Advertisement advertisement)
        {
            throw new NotImplementedException();
        }
    }
}
