using ECOSAGE.DATA.db;
using ECOSAGE.DATA.models.carbonFootprint;
using ECOSAGE.REPOSITORY.carbonFootprint;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECOSAGE.TESTS
{
    public class CarbonFootprintTest
    {
        private OracleDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<OracleDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            return new OracleDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddCarbonFootprintToDatabase()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var repository = new CarbonFootprintRepository(context);

            var carbonFootprint = new CarbonFootprint
            {
                CarbonFootprintId = 1,
                UserId = 1,
                TotalEmission = 100.5m
            };

            // Act
            await repository.AddAsync(carbonFootprint);

            // Assert
            var savedCarbonFootprint = await context.CarbonFootprints.FirstOrDefaultAsync(c => c.CarbonFootprintId == carbonFootprint.CarbonFootprintId);
            Assert.NotNull(savedCarbonFootprint);
            Assert.Equal(carbonFootprint.TotalEmission, savedCarbonFootprint.TotalEmission);
        }
    }
}
