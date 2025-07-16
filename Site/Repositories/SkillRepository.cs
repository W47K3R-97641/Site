using Site.Data;
using Site.Entites;
using Site.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Site.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.Include(s => s.Projects).ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skills.Include(s => s.Projects)
                                        .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
             _context.Skills.Update(skill);
        }

        public async Task DeleteAsync(int id)
        {
            var skill = await GetByIdAsync(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
