using BeamlineX.Domain;
using BeamlineX.Repositories;
using BeamlineX.Repositories.Abstraction;

using FluentAssertions;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace BeamlineX.RepositoriesTests
{
    public class RepositoryTests
    {
        private readonly BeamlineXDbContext _dbContext;

        public RepositoryTests()
        {
            DbContextOptions<BeamlineXDbContext>? options = new DbContextOptionsBuilder<BeamlineXDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            _dbContext = new(options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        [Fact(DisplayName = "GetAllAsync should return all Elements")]
        public async Task GetAllAsyncTest()
        {
            IRepository repo = new Repository(_dbContext);
            Customer customer1 = new("C1");
            Customer customer2 = new("C2");
            await _dbContext.AddAsync(customer1);
            await _dbContext.AddAsync(customer2);
            await _dbContext.SaveChangesAsync();

            ICollection<Customer> result = await repo.GetAllAsync<Customer>();

            result.Should().BeEquivalentTo(new[] { customer1, customer2 });
        }
    }
}