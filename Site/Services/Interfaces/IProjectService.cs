using Site.Entites;

namespace Site.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Dtos.DisplayProjectDto?> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Dtos.CreateProjectDto project);
        Task UpdateProjectAsync(Project project);
        Task Delete(int id);
    }
}
