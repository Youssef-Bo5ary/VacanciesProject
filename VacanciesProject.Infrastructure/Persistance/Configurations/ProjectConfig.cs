using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Infrastructure.Persistance.Configurations;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
	public void Configure(EntityTypeBuilder<Project> builder)
	{
		builder.HasOne(a => a.User)
			.WithMany(u => u.projects)
			.HasForeignKey(a => a.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
