
using Microsoft.AspNetCore.Identity;
using VacanciesProject.Domain.Enum;

namespace VacanciesProject.Domain.Entity;

public class AppUser : IdentityUser<int>
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public DateOnly? BirthDate { get; set; }
	public bool IsActive { get; set; } = true;
	public UserType userType { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	
	public ICollection<Project> projects { get; set; } = new List<Project>();
}
