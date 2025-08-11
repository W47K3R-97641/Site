using Site.Entites;
using Site.Dtos;

namespace Site.Mappings
{
    public static class ProjectMappingExtensions
    {
        public static DisplayProjectDto ToDisplayProjectDto(this Project project)
        {
            return new DisplayProjectDto
            {
                Name = project.Name,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                DemoLink = project.DemoLink,
                Completed = project.Completed,
                GitHubLink = project.GitHubLink,
                SkillIds = project.Skills.Select(s => s.Id).ToList(),
                SkillNames = project.Skills.Select(s => s.Name).ToList()
            };
        }
    }

}
