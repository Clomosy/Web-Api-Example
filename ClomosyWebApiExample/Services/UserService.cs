using ClomosyWebApiExample.DTOs;
using ClomosyWebApiExample.Models;
using ClomosyWebApiExample.Helpers;
using ClomosyWebApiExample.Repositories;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ClomosyWebApiExample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public string Authenticate(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByUsername(loginDto.Username);

            if (user == null || !PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
                return null;

            return JwtHelper.GenerateJwtToken(user, _jwtSettings);
        }

        public bool Register(RegisterDto registerDto)
        {
            // Kullanıcının var olup olmadığını kontrol et
            if (_userRepository.GetUserByUsername(registerDto.Username) != null)
                return false; // Kullanıcı zaten mevcut

            // Kullanıcıyı oluştur
            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            _userRepository.AddUser(user);
            return true;
        }

        public User GetUser(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                return null;

            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username
            };
        }
    }
}
