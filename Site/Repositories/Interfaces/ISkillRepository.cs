using Microsoft.EntityFrameworkCore;
using Site.Entites;

namespace Site.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllAsync(bool includeProject = false, bool tracking = false);

        Task<Skill?> GetByIdAsync(int id);

        Task<List<Skill>> GetByIdsAsync(IEnumerable<int> ids, bool includeProject = false, bool tracking = false);
        Task<Skill?> GetByIdAsync(int id, bool includeProject = false, bool tracking = false);

        Task AddAsync(Skill skill);

        Task UpdateAsync(Skill skill);

        Task DeleteAsync(int id);

        Task SaveAsync();
    }
}
