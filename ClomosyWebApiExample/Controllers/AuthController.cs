namespace ClomosyWebApiExample.Controllers
{
    using ClomosyWebApiExample.DTOs;
    using ClomosyWebApiExample.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            var result = _userService.Register(registerDto);
            if (!result)
                return BadRequest((new { Status = "Error", Message = "Hatalı bilgi girişi" }));

            return Ok(new
            {
                Status = "Success",
            });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var token = _userService.Authenticate(loginDto);

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { Status = "Error", Message = "Geçersiz kimlik bilgileri." });

            return Ok(new
            {
                Status = "Success",
                Token = token
            });
        }


        [HttpGet("profile")]
        [Authorize] // Bu endpoint'e yalnızca yetkili kullanıcılar erişebilir
        public IActionResult GetProfile()
        {
            // JWT'den gelen kullanıcı adını alıyoruz
            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
                return Unauthorized( new { Status = "Error", Message = "Geçersiz token." });

            var profile = _userService.GetUser(username);
            if (profile == null)
                return NotFound (new { Status = "Error", Message = "Kullanıcı bulunamadı." });

            return Ok(new { Status = "True", profile});
        }
    }
}
