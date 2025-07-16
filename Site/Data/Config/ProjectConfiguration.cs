using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Site.Entites;

namespace Site.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.ImageUrl)
                   .HasMaxLength(255);

            builder.Property(p => p.DemoLink)
                   .HasMaxLength(255);

            builder.Property(p => p.GitHubLink)
                   .HasMaxLength(255);

            builder.Property(p => p.Completed)
                   .HasDefaultValue(false);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Many-to-many
            builder
                .HasMany(p => p.Skills)
                .WithMany(s => s.Projects)
                .UsingEntity(j => j.ToTable("ProjectSkills"));

            // Seed Projects only (no navigation)
            builder.HasData(
                new Project
                {
                    Id = 1,
                    Name = "Walker Creator Platform",
                    Description = "A platform for Walkers to create and share projects.",
                    ImageUrl = "https://i.pinimg.com/736x/d3/3d/32/d33d326d8465cf9663652a4f0c426159.jpg",
                    DemoLink = "https://simple.cruip.com",
                    GitHubLink = "https://github.com/walkercreator/walkerplatform",
                    Completed = true,
                    CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Project
                {
                    Id = 2,
                    Name = "Unity Showcase",
                    Description = "An open-source site built to demo Unity-powered collaborations.",
                    ImageUrl = "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740",
                    DemoLink = "https://simple.cruip.com",
                    GitHubLink = "https://github.com/unityshowcase/demo",
                    Completed = false,
                    CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                 new Project
                 {
                     Id = 3,
                     Name = "Ecommerce Project",
                     Description = "An open-source site built to demo Unity-powered collaborations.",
                     ImageUrl = "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740",
                     DemoLink = "https://simple.cruip.com",
                     GitHubLink = "https://github.com/unityshowcase/demo",
                     Completed = false,
                     CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc)
                 },
                 new Project
                 {
                     Id = 4,
                     Name = "Potflio",
                     Description = "An open-source site built to demo Unity-powered collaborations.",
                     ImageUrl = "https://img.freepik.com/vecteurs-libre/ensemble-modeles-conception-page-destination-site-web-moderne-pour-telephone-mobile-tablette-articles-galerie-formulaire-contact-illustration-isolee-plat_1284-60948.jpg?semt=ais_hybrid&w=740",
                     DemoLink = "https://simple.cruip.com",
                     GitHubLink = "https://github.com/unityshowcase/demo",
                     Completed = false,
                     CreatedAt = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc)
                 }
            );
        }
    }
}
