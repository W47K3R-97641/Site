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
        public async Task<IEnumerable<Skill>> GetAllAsync(bool includeProject = false, bool tracking = false)
        {
            IQueryable<Skill> query = _context.Skills;

            if (includeProject)
            {
                query = query.Include(s => s.Projects);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
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

        public async Task<Skill?> GetByIdAsync(int id, bool includeProject = false, bool tracking = false)
        {
            IQueryable<Skill> query = _context.Skills;

            if (includeProject)
            {
                query = query.Include(s => s.Projects);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Skill>> GetByIdsAsync(IEnumerable<int> ids, bool includeProject = false, bool tracking = false)
        {
            IQueryable<Skill> query = _context.Skills;

            if (includeProject)
            {
                query =  query.Include(s => s.Projects);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.Where(skill => ids.Contains(skill.Id)).ToListAsync();
        }

    }
}
