using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Domain.Entity;
using VacanciesProject.DTOs;

namespace VacanciesProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public AuthController(
			SignInManager<AppUser> signInManager,
			IJwtTokenService jwtTokenService,
			UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_jwtTokenService = jwtTokenService;
			_userManager = userManager;
		}
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IJwtTokenService _jwtTokenService;
		private readonly UserManager<AppUser> _userManager;


		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterRequestDto request)
		{
			var user = new AppUser
			{
				UserName = request.Email,
				Email = request.Email,
				FirstName = request.FirstName,
				LastName = request.LastName,
				userType = request.UserType
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
				return BadRequest(result.Errors);

			return Ok(result);

			//return Ok("User registered successfully");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginRequestDto request)
		{
			var user = await _userManager.FindByNameAsync(request.Email);
			//var user = await _userManager.FindByEmailAsync(request.Email);

			if (user == null )
				return Unauthorized("Invalid credentials");

			if (!await _userManager.CheckPasswordAsync(user, request.Password))
			{
				return Unauthorized("Invalid credentials");
			}


			var token = await _jwtTokenService.GenerateTokenAsync(user);

			return Ok(new { token });
		}

	}
}
