using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.activity.dto;
using ECOSAGE.REPOSITORY.activity;

namespace ECOSAGE.SERVICE.activity
{
    public class ActivityService
    {
        private readonly ActivityRepository _repository;

        public ActivityService(ActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEnergyActivityAsync(EnergyActivityRequestDto dto)
        {
            if (await ActivityExists(dto.Name))
                throw new ArgumentException("Activity with this name already exists.");

            var activity = new Activity
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Description = dto.Description,
                Category = "energia",
                Emission = CalculateEnergyEmission(dto.HoursUsed)
            };

            await _repository.AddAsync(activity);
        }

        public async Task AddTransportActivityAsync(TransportActivityRequestDto dto)
        {
            if (await ActivityExists(dto.Name))
                throw new ArgumentException("Activity with this name already exists.");

            var activity = new Activity
            {
                UserId = dto.UserId,
                Name = dto.Name,
                Description = dto.Description,
                Category = "transporte",
                Emission = CalculateTransportEmission(dto.KilometersTravelled)
            };

            await _repository.AddAsync(activity);
        }

        public async Task<ActivityResponseDto> GetActivityByIdAsync(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                throw new KeyNotFoundException("Activity not found.");

            return MapActivityToDto(activity);
        }

        public async Task DeleteActivityAsync(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                throw new KeyNotFoundException("Activity not found.");

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ActivityResponseDto>> GetAllAsync()
        {
            var activities = await _repository.GetAllAsync();
            return activities.Select(MapActivityToDto); // Mapeia para DTO antes de retornar
        }

        private async Task<bool> ActivityExists(string name)
        {
            var activities = await _repository.GetAllAsync();
            return activities.Any(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private decimal CalculateEnergyEmission(int hoursUsed)
        {
            return 0.5m * hoursUsed;
        }

        private decimal CalculateTransportEmission(decimal kilometersTravelled)
        {
            return 0.2m * kilometersTravelled;
        }

        private ActivityResponseDto MapActivityToDto(Activity activity)
        {
            return new ActivityResponseDto
            {
                ActivityId = activity.ActivityId,
                Name = activity.Name,
                Description = activity.Description,
                Category = activity.Category,
                Emission = activity.Emission,
                CarbonFootprintId = activity.CarbonFootprintId
            };
        }
    }
}
