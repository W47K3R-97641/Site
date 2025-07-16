using Site.Entites;
using Site.Repositories.Interfaces;
using Site.Services.Interfaces;

namespace Site.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepo;

        public SkillService(ISkillRepository skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
            => await _skillRepo.GetAllAsync();

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
    }
}
