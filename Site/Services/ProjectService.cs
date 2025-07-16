using Site.Entites;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
            => await _projectRepo.GetAllAsync();

        public async Task<Project?> GetProjectByIdAsync(int id)
            => await _projectRepo.GetByIdAsync(id);

        public async Task AddProjectAsync(Project project)
        {
            await _projectRepo.AddAsync(project);
            await _projectRepo.SaveAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _projectRepo.UpdateAsync(project);
            await _projectRepo.SaveAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepo.DeleteAsync(id);
            await _projectRepo.SaveAsync();
        }
    }
}
