using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.DATA.models.carbonFootprint.dto;
using ECOSAGE.REPOSITORY.activity;
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

        private readonly ActivityRepository _activityRepository;

        public CarbonFootprintService(CarbonFootprintRepository repository, ActivityRepository activityRepository)
        {
            _repository = repository;
            _activityRepository = activityRepository;
        }

        public async Task<List<CarbonFootprintResponseDto>> GetAllCarbonFootprintsAsync()
        {
            var carbonFootprints = await _repository.GetAllAsync();

            if (carbonFootprints == null || !carbonFootprints.Any())
            {
                return new List<CarbonFootprintResponseDto>();
            }

            var result = carbonFootprints.Select(cf => new CarbonFootprintResponseDto
            {
                CarbonFootprintId = cf.CarbonFootprintId,
                TimeStamp = cf.TimeStamp,
                TotalEmission = cf.TotalEmission,
                Activities = cf.Activities.Select(a => new ActivityResponseDto
                {
                    ActivityId = a.ActivityId,
                    Name = a.Name,
                    Emission = a.Emission
                }).ToList()
            }).ToList();

            return result;
        }

        public async Task<CarbonFootprintResponseDto> GetCarbonFootprintByIdAsync(int id)
        {
            var carbonFootprint = await _repository.GetByIdAsync(id);

            if (carbonFootprint == null)
                throw new KeyNotFoundException("Carbon Footprint not found.");

            var result = new CarbonFootprintResponseDto
            {
                CarbonFootprintId = carbonFootprint.CarbonFootprintId,
                TimeStamp = carbonFootprint.TimeStamp,
                TotalEmission = carbonFootprint.TotalEmission,
                Activities = carbonFootprint.Activities.Select(a => new ActivityResponseDto
                {
                    ActivityId = a.ActivityId,
                    Name = a.Name,
                    Emission = a.Emission
                }).ToList()
            };

            return result;
        }


        public async Task CreateCarbonFootprintAsync(CarbonFootprintRequestDto dto)
        {
            var activities = new List<Activity>();

            foreach (var activityId in dto.ActivityIds)
            {
                var activity = await _activityRepository.GetByIdAsync(activityId);
                if (activity != null)
                {
                    activities.Add(activity);
                }
                else
                {
                    throw new ArgumentException($"No activity found with ID {activityId}.");
                }
            }

            if (activities.Count == 0)
                throw new ArgumentException("No activities found with the provided IDs.");

            var carbonFootprint = new CarbonFootprint
            {
                UserId = dto.UserId,
                Activities = activities,
                TotalEmission = activities.Sum(a => a.Emission)
            };

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
