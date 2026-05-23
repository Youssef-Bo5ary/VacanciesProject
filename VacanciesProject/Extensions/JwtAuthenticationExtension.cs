using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VacanciesProject.Application.Common;

namespace VacanciesProject.Extensions
{
	public static class JwtAuthenticationExtension
	{
		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtSettings>(
			   configuration.GetSection("Jwt"));

			var jwtSettings = configuration
				.GetSection("Jwt")
				.Get<JwtSettings>()
				?? throw new InvalidOperationException("JWT settings are missing");

			var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = jwtSettings.Issuer,
					ValidAudience = jwtSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(key),

					ClockSkew = TimeSpan.Zero
				};
			});

			services.AddAuthorization();

			return services;
		}
	}
}
