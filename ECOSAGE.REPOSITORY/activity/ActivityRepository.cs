using ECOSAGE.DATA.db;
using ECOSAGE.DATA.models.activity;
using Microsoft.EntityFrameworkCore;


namespace ECOSAGE.REPOSITORY.activity
{
    public class ActivityRepository
    {
        private readonly OracleDbContext _context;

        public ActivityRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            return await _context.Activities.Include(a => a.CarbonFootprint).ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activities
                .Include(a => a.CarbonFootprint)
                .FirstOrDefaultAsync(a => a.ActivityId == id);
        }

        public async Task AddAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Activity activity)
        {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await GetByIdAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
