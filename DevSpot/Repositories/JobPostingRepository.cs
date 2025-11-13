using DevSpot.Data;
using DevSpot.Models;
using Microsoft.EntityFrameworkCore;

namespace DevSpot.Repositories
{
    public class JobPostingRepository : IRepository<JobPosting>
    {

        private readonly ApplicationDbContext _context;
        public JobPostingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(JobPosting entity)
        {
            await _context.JobPostings.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var jobPostings = await _context.JobPostings.FindAsync(id);
            if (jobPostings == null)
            {
                throw new KeyNotFoundException();
            }
            _context.JobPostings.Remove(jobPostings);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobPosting>> GetAllAsync()
        {
            return await _context.JobPostings.ToListAsync();
        }

        public async Task<JobPosting> GetByIdAsync(int id)
        {
            var jobPosting = await _context.JobPostings.FindAsync(id);
            if (jobPosting == null)
            {
                throw new KeyNotFoundException();
            }
            return jobPosting;
        }

        public async Task UpdateAsync(JobPosting entity)
        {
            _context.JobPostings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
