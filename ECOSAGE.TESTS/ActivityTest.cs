using ECOSAGE.DATA.db;
using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.DATA.models.carbonFootprint.dto;
using ECOSAGE.REPOSITORY.activity;
using ECOSAGE.REPOSITORY.carbonFootprint;
using ECOSAGE.SERVICE.carbonFootprint;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ECOSAGE.TESTS
{
    public class ActivityTest
    {
        public class ActivityRepositoryTests
        {
            private OracleDbContext CreateInMemoryContext()
            {
                var options = new DbContextOptionsBuilder<OracleDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
                return new OracleDbContext(options);
            }

            [Fact]
            public async Task AddAsync_ShouldAddActivityToDatabase()
            {
                // Arrange
                var context = CreateInMemoryContext();
                var repository = new ActivityRepository(context);

                var activity = new Activity
                {
                    ActivityId = 1,
                    UserId = 1,
                    Name = "Test Activity",
                    Description = "Test Description",
                    Category = "Test Category",
                    Emission = 10.5m,
                    CarbonFootprint = null
                };

                // Act
                await repository.AddAsync(activity);

                // Assert
                var savedActivity = await context.Activities.FirstOrDefaultAsync(a => a.ActivityId == activity.ActivityId);
                Assert.NotNull(savedActivity);
                Assert.Equal(activity.Name, savedActivity.Name);
                Assert.Equal(activity.Emission, savedActivity.Emission);
            }
        }
    }
}