using Data.ApplicationDbContext;
using Domain.Services;

namespace Domain.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TestDbContext _repoContext;
        private ICompanyRepository _companyRepository;
        private IContactRepository _contactRepository;
        private ICountryRepository _countryRepository;

        public RepositoryWrapper(TestDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new ICompanyRepository(_repoContext);
                }
                return _companyRepository;
            }
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_repoContext);
                }
                return _contactRepository;
            }
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}

