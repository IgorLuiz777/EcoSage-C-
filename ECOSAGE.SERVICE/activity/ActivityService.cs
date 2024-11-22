using ECOSAGE.DATA.models.activity;
using ECOSAGE.REPOSITORY.activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.SERVICE.activity
{
    public class ActivityService
    {
        private readonly ActivityRepository _repository;

        public ActivityService(ActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Activity?> GetActivityByIdAsync(int id)
        {
            var activity = await _repository.GetByIdAsync(id);
            if (activity == null)
                throw new KeyNotFoundException("Activity not found.");
            return activity;
        }

        public async Task AddActivityAsync(Activity activity)
        {
            if (await ActivityExists(activity.Name))
                throw new ArgumentException("Activity with this name already exists.");

            await _repository.AddAsync(activity);
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            var existingActivity = await _repository.GetByIdAsync(activity.ActivityId);

            if (existingActivity == null)
                throw new KeyNotFoundException("Activity not found.");

            existingActivity.Name = activity.Name;
            existingActivity.Description = activity.Description;
            existingActivity.Category = activity.Category;

            await _repository.UpdateAsync(existingActivity);
        }

        public async Task DeleteActivityAsync(int id)
        {
            var existingActivity = await _repository.GetByIdAsync(id);
            if (existingActivity == null)
                throw new KeyNotFoundException("Activity not found.");

            await _repository.DeleteAsync(id);
        }

        private async Task<bool> ActivityExists(string name)
        {
            var activities = await _repository.GetAllAsync();
            return activities.Any(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
