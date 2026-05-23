using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VacanciesProject.Domain.Entity;

namespace VacanciesProject.Infrastructure.Persistance.Configurations;

public class TasksConfig : IEntityTypeConfiguration<Taskss>
{
	public void Configure(EntityTypeBuilder<Taskss> builder)
	{
		builder.HasOne(a => a.Project)
			.WithMany(u => u.Tasks)
			.HasForeignKey(a => a.ProjectId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
