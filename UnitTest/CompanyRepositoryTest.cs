using Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class CompanyRepositoryTest
    {
        private DbContextOptions<TestDbContext> dbContextOptions;

        public CompanyRepositoryTest()
        {
            var dbName = $"TestDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }
        [Fact]
        public async Task GetCompanyAsync_Success_Test()
        {
            var repository = await CreateCompanyAsync();

            // Act
            var companyList = await repository.GetCompanyAsync();

            // Assert
            Assert.Equal(3, companyList.Count);
        }
    }
}
