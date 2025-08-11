using Site.Entites;

namespace Site.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync(bool includeSkill = false, bool tracking = false);

        Task<Project?> GetByIdAsync(int id, bool includeSkill = false, bool tracking = false);

        Task AddAsync(Project project);

        void Update(Project project);

        Task Delete(int id);

        Task SaveAsync();
    }
}
