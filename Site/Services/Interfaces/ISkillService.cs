using Site.Entites;

namespace Site.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkillsAsync(bool includeProject = false, bool tracking = false);
        Task<Skill?> GetSkillByIdAsync(int id);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(int id);
        Task<List<Skill>> GetByIdsAsync(IEnumerable<int> ids, bool includeProject = false, bool tracking = false);
    }
}
