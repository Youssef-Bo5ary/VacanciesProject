
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VacanciesProject.Application.Common;
using VacanciesProject.Application.Interfaces;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Services;

public class JwtServices : IJwtTokenService
{
	
		private readonly JwtSettings _options;
	private readonly UserManager<AppUser> _userManager;

	public JwtServices(
		IOptions<JwtSettings> options,
		UserManager<AppUser> userManager)
	{
		_options = options.Value;
		_userManager = userManager;
	}

	public async Task<string> GenerateTokenAsync(AppUser user)
	{
		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
			new(JwtRegisteredClaimNames.Email, user.Email!),
			new("UserType", user.userType.ToString()),
			new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

		var roles = await _userManager.GetRolesAsync(user);
		foreach (var role in roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}

		var key = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(_options.Key));

		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			issuer: _options.Issuer,
			audience: _options.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(_options.DurationInMinutes),
			signingCredentials: creds
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}

