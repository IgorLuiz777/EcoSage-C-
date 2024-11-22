using ECOSAGE.DATA.db;
using ECOSAGE.DATA.models.carbonFootprint;
using Microsoft.EntityFrameworkCore;


namespace ECOSAGE.REPOSITORY.carbonFootprint
{
    public class CarbonFootprintRepository
    {
        private readonly OracleDbContext _context;

        public CarbonFootprintRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarbonFootprint>> GetAllAsync()
        {
            return await _context.CarbonFootprints.Include(c => c.Activities).ToListAsync();
        }

        public async Task<CarbonFootprint?> GetByIdAsync(int id)
        {
            return await _context.CarbonFootprints
                .Include(c => c.Activities)
                .FirstOrDefaultAsync(c => c.CarbonFootprintId == id);
        }

        public async Task AddAsync(CarbonFootprint carbonFootprint)
        {
            await _context.CarbonFootprints.AddAsync(carbonFootprint);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarbonFootprint carbonFootprint)
        {
            _context.CarbonFootprints.Update(carbonFootprint);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carbonFootprint = await GetByIdAsync(id);
            if (carbonFootprint != null)
            {
                _context.CarbonFootprints.Remove(carbonFootprint);
                await _context.SaveChangesAsync();
            }
        }
    }
}
