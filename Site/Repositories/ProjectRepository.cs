using Site.Data;
using Site.Entites;
using Site.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Blazorise;

namespace Site.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(bool includeSkill = false, bool tracking = false)
        {
            IQueryable<Project> query = _context.Projects;

            if (includeSkill)
            {
                query = query.Include(p => p.Skills);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }


        public async Task<Project?> GetByIdAsync(int id, bool includeSkill = false, bool tracking = false)
        {
            IQueryable<Project> query = _context.Projects;

            if (includeSkill)
            {
                query = query.Include(p => p.Skills);
            }

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public async Task Delete(int id)
        {
            var project = await GetByIdAsync(id);
            if (project is not null)
            {
                _context.Projects.Remove(project);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
