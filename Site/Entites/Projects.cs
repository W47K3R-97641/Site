using System.ComponentModel.DataAnnotations;

namespace Site.Entites
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string? DemoLink { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public string GitHubLink { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }


}