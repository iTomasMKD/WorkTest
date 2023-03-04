using Data.ApplicationDbContext;
using Data.Entities;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class CompanyRepoistory : RepositoryBase<Country>, ICountryRepository
    {

        public CompanyRepoistory(TestDbContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Country>> GetAllCountrysAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.CountryId)
               .ToListAsync();
        }
        public async Task<Country> GetCountryByIdAsync(Guid CountryId)
        {
            return await FindByCondition(Country => Country.CountryId.Equals(CountryId))
                .FirstOrDefaultAsync();
        }
        public async Task<Country> GetCountryWithDetailsAsync(Guid CountryId)
        {
            return await FindByCondition(Country => Country.CountryId.Equals(CountryId))
                .Include(ac => ac.Contact)
                .FirstOrDefaultAsync();
        }
        public void CreateCountry(Country Country)
        {
            Create(Country);
        }
        public void UpdateCountry(Country Country)
        {
            Update(Country);
        }
        public void DeleteCountry(Country Country)
        {
            Delete(Country);
        }
    }
}
