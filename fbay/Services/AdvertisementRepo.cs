using AutoMapper;
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


        public async Task DeleteAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null)
            {
                throw new ArgumentNullException(nameof(advertisement));
            }

            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task<Advertisement> GetAdvertisementById(int id)
        {
            try
            {
                return await _context.Advertisements
                    .Include(adrs => adrs.addressToTakes)
                    .Include(img => img.ImageUrls)
                    .Include(keys => keys.keywords)
                    .Where(adv => adv.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e )
            {

                throw new ArgumentNullException(nameof(e));
            }
        }

        public Task<Advertisement> GetAdvertisementByKeyWords(int id, string size, string[] keywords)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Advertisement>> GetAdvertisementByUserrId(int id)
        {
            try
            {
                var advs = await _context.Users
                .Include(advs => advs.advertisements)
                .Where(u => u.Id == id).FirstOrDefaultAsync();

                if(advs == null)
                {
                    throw new ArgumentNullException(nameof(advs));
                }

                return advs.advertisements;
            }
            catch (Exception e)
            {

                throw new ArgumentNullException(nameof(e));
            }
           
        }

        public async Task<IEnumerable<Advertisement>> GetAllAdvs()
        {
            var advs = await _context.Advertisements
                .Include(adrs => adrs.addressToTakes)
                .Include(img => img.ImageUrls)
                .Include(keys => keys.keywords).ToListAsync();

            return advs;
        }

        public async Task UpdateAdvertisement(Advertisement advertisement)
        {
            await _context.SaveChangesAsync();
        }
    }
}
