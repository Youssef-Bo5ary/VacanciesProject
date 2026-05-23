using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Application.Interfaces;

public interface IJwtTokenService
{
	Task<string> GenerateTokenAsync(AppUser user);

}
