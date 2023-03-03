using Data.ApplicationDbContext;
using Data.Entities;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class ICompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {

        public CompanyRepository(TestDbContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Company>> GetAllCompanysAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.CompanyId)
               .ToListAsync();
        }
        public async Task<Company> GetCompanyByIdAsync(Guid CompanyId)
        {
            return await FindByCondition(Company => Company.CompanyId.Equals(CompanyId))
                .FirstOrDefaultAsync();
        }
        public async Task<Company> GetCompanyWithDetailsAsync(Guid CompanyId)
        {
            return await FindByCondition(Company => Company.CompanyId.Equals(CompanyId))
                .Include(ac => ac.Contact)
                .FirstOrDefaultAsync();
        }
        public void CreateCompany(Company Company)
        {
            Create(Company);
        }
        public void UpdateCompany(Company Company)
        {
            Update(Company);
        }
        public void DeleteCompany(Company Company)
        {
            Delete(Company);
        }
    }
}
