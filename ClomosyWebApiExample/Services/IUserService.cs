using ClomosyWebApiExample.DTOs;
using ClomosyWebApiExample.Models;

namespace ClomosyWebApiExample.Services
{
    public interface IUserService
    {
        string Authenticate(LoginDto loginDto);
        bool Register(RegisterDto registerDto);
        User GetUser(string username);
    }

}
