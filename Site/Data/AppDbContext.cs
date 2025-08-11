using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Site.Data.Config;
using Site.Entites;

namespace Site.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Add any additional properties for ApplicationUser here if needed  
    }

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new ProjectConfiguration())
                .ApplyConfiguration(new SkillConfiguration());

            // Many-to-many seeding  
            modelBuilder.Entity("ProjectSkill").HasData(
                new { ProjectsId = 1, SkillsId = 1 }, // Project 1 - C#  
                new { ProjectsId = 1, SkillsId = 2 }, // Project 1 - React  
                new { ProjectsId = 1, SkillsId = 3 }, // Project 1 - SQL  

                new { ProjectsId = 2, SkillsId = 2 }, // Project 2 - React  
                new { ProjectsId = 2, SkillsId = 1 },  // Project 2 - C#  

                new { ProjectsId = 3, SkillsId = 2 },
                new { ProjectsId = 3, SkillsId = 1 },
                new { ProjectsId = 3, SkillsId = 4 },
                new { ProjectsId = 3, SkillsId = 5 },

                new { ProjectsId = 4, SkillsId = 4 }
            );
        }
    }
}
