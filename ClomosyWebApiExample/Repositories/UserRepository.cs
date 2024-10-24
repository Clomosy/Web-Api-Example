using ClomosyWebApiExample.Data;
using ClomosyWebApiExample.Data.ClomosyWebApiExample.Data;
using ClomosyWebApiExample.Models;
using System.Linq;

namespace ClomosyWebApiExample.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
