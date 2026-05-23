using System.Security.Claims;
using VacanciesProject.Application.Interfaces;

namespace VacanciesProject.CurrentUser;

public class CurrentUserService : ICurrentUserService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public CurrentUserService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public int? UserId
	{
		get
		{
			var userIdClaim = _httpContextAccessor.HttpContext?
				.User?
				.FindFirst(ClaimTypes.NameIdentifier); // أو اسم الـ claim الحقيقي

			if (userIdClaim == null)
				return null;

			return int.Parse(userIdClaim.Value);
		}
	}
	//public int UserId
	//	=> int.Parse(
	//		_httpContextAccessor.HttpContext!
	//			.User
	//			.FindFirst("userId")!.Value);


}
