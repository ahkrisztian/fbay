using fbay.Data;
using fbay.Models;
using Microsoft.EntityFrameworkCore;

namespace fbay.Services
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using (_context)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users
                .Include(a => a.Addresses)
                .Include(adv => adv.advertisements).ToListAsync();

            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users
                .Include(a => a.Addresses)
                .Include(adv => adv.advertisements)
                .FirstOrDefaultAsync(u => u.Id == id);


            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }

        public async Task UpdateUser(User user)
        {

            await _context.SaveChangesAsync();
            
        }
    }
}
