using ClomosyWebApiExample.Models;

namespace ClomosyWebApiExample.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void AddUser(User user);
    }
}
