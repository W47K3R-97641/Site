using Microsoft.Build.Evaluation;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace Site.Dtos
{
    public class CreateProjectDto
    {
        [Required, StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required, Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Url]
        public string? DemoLink { get; set; }

        public bool Completed { get; set; }

        [Required, Url]
        public string GitHubLink { get; set; } = string.Empty;

        public List<int> SkillIds { get; set; } = new();
    }

    public class DisplayProjectDto : CreateProjectDto
    {
        public IReadOnlyList<string> SkillNames { get; set; } = Array.Empty<string>();
    }
}
