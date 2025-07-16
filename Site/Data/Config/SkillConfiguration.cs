using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Site.Entites;

namespace Site.Data.Config
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.Property(s => s.IconUrl)
                   .HasMaxLength(255);

            builder.Property(s => s.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Seed Skills
            builder.HasData(
                new Skill { Id = 1, Name = "C#", Description = "Backend", IconUrl = "", CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Skill { Id = 2, Name = "React", Description = "Frontend", IconUrl = "", CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Skill { Id = 3, Name = "SQL Server", Description = "Database", IconUrl = "", CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Skill { Id = 4, Name = "Blazor", Description = "frontend", IconUrl = "", CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Skill { Id = 5, Name = "Asp.net", Description = "api", IconUrl = "", CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc) }

            );
        }
    }
}
