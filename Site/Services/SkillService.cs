using Site.Entites;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Site.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepo;

        public SkillService(ISkillRepository skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<List<Skill>> GetAllSkillsAsync(bool includeProject = false, bool tracking = false)
        {
            var skills = await _skillRepo.GetAllAsync(includeProject, tracking);
            return skills.ToList();
           
        }
            

        public async Task<Skill?> GetSkillByIdAsync(int id)
            => await _skillRepo.GetByIdAsync(id);

        public async Task AddSkillAsync(Skill skill)
        {
            await _skillRepo.AddAsync(skill);
            await _skillRepo.SaveAsync();
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            await _skillRepo.UpdateAsync(skill);
            await _skillRepo.SaveAsync();
        }

        public async Task DeleteSkillAsync(int id)
        {
            await _skillRepo.DeleteAsync(id);
            await _skillRepo.SaveAsync();
        }

       
        public async Task<List<Skill>> GetByIdsAsync(IEnumerable<int> ids, bool includeProject = false, bool tracking = false)
        {
            return await _skillRepo.GetByIdsAsync(ids, includeProject, tracking);
        }
    }
}
