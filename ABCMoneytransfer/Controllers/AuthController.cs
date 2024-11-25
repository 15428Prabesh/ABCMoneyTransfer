using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ABCMoneytransfer.Controllers
{
	public class AuthController : Controller
	{
		private readonly UserServices _userServices;

		public AuthController(UserServices userServices)
		{
			_userServices = userServices;
		}
		[HttpGet]
		public IActionResult Register() => View();
		[HttpPost]
		public async Task<IActionResult> Register(RegisterUserDto dto)
		{
			if (ModelState.IsValid) { 
				var result = await _userServices.RegisterUserAsync(dto);
				if (result)
				{
					return RedirectToAction("Login");
				}
				ModelState.AddModelError(string.Empty,"Registration Failed.");
			}
			return View(dto);
		}

		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginDto dto)
		{
            if (!ModelState.IsValid)
            {
				return View(dto);
            }
            try
            {
                var user = await _userServices.ValidateUser(dto.Username,dto.Password);
                if (user != null)
                {
					var claims = new List<Claim>
				{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
					new Claim(ClaimTypes.Role, user.UserRole)};

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while logging in: {ex.Message}");
            }
            return View(dto);
		}
		//public IActionResult Index()
		//{
		//	return View();
		//}
	}
}
