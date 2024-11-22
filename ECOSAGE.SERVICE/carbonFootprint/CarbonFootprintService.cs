using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.REPOSITORY.carbonFootprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.SERVICE.carbonFootprint
{
    public class CarbonFootprintService
    {
        private readonly CarbonFootprintRepository _repository;

        public CarbonFootprintService(CarbonFootprintRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CarbonFootprint>> GetAllCarbonFootprintsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CarbonFootprint?> GetCarbonFootprintByIdAsync(int id)
        {
            var carbonFootprint = await _repository.GetByIdAsync(id);
            if (carbonFootprint == null)
                throw new KeyNotFoundException("Carbon Footprint not found.");
            return carbonFootprint;
        }

        public async Task AddCarbonFootprintAsync(CarbonFootprint carbonFootprint)
        {
            carbonFootprint.TotalEmission = carbonFootprint.Activities.Sum(a => a.Emission);
            await _repository.AddAsync(carbonFootprint);
        }

        public async Task UpdateCarbonFootprintAsync(CarbonFootprint carbonFootprint)
        {
            var existingCarbonFootprint = await _repository.GetByIdAsync(carbonFootprint.CarbonFootprintId);
            if (existingCarbonFootprint == null)
                throw new KeyNotFoundException("Carbon Footprint not found.");

            existingCarbonFootprint.Activities = carbonFootprint.Activities;
            existingCarbonFootprint.TotalEmission = carbonFootprint.Activities.Sum(a => a.Emission);

            await _repository.UpdateAsync(existingCarbonFootprint);
        }

        public async Task DeleteCarbonFootprintAsync(int id)
        {
            var existingCarbonFootprint = await _repository.GetByIdAsync(id);
            if (existingCarbonFootprint == null)
                throw new KeyNotFoundException("Carbon Footprint not found.");
            await _repository.DeleteAsync(id);
        }
    }
}
