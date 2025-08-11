using Site.Entites;
using Site.Dtos;

using Site.Mappings;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;
using Site.Repositories;
using Site.CustomExceptions;

namespace Site.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly ISkillRepository _skillRepo;



        public ProjectService(IProjectRepository projectRepo, ISkillRepository skillRepo)
        {
            _projectRepo = projectRepo;
            _skillRepo = skillRepo;

        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
            => await _projectRepo.GetAllAsync();

       

        public async Task<Dtos.DisplayProjectDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);

            if (project == null)
            {
                return null;
            }

            return project.ToDisplayProjectDto();
        }
        public async Task AddProjectAsync(Project project)
        {
            await _projectRepo.AddAsync(project);
            await _projectRepo.SaveAsync();
        }

        public async Task AddProjectAsync(CreateProjectDto projectDto)
        {
            // Fetch all skills matching the given IDs
            var skills = await _skillRepo.GetByIdsAsync(projectDto.SkillIds);

            // Determine if any skill IDs were not found
            var missingSkillIds = projectDto.SkillIds.Except(skills.Select(s => s.Id)).ToList();
            if (missingSkillIds.Count > 0)
            {
                throw new SkillNotFoundException(missingSkillIds);
            }

            // Map DTO to Entity
            var project = new Project
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                ImageUrl = projectDto.ImageUrl,
                GitHubLink = projectDto.GitHubLink,
                Completed = projectDto.Completed,
                Skills = skills,
                CreatedAt = DateTime.UtcNow,
            };

            // Persist to database
            await _projectRepo.AddAsync(project);
            await _projectRepo.SaveAsync();
        }




        public async Task UpdateProjectAsync(Project project)
        {
            _projectRepo.Update(project);
            await _projectRepo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _projectRepo.Delete(id);
            await _projectRepo.SaveAsync();
        }
    }
}
