using Data.ApplicationDbContext;
using Data.Entities;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    internal class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {

        public ContactRepository(TestDbContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.ContactId)
               .ToListAsync();
        }
        public async Task<Contact> GetContactByIdAsync(Guid ContactId)
        {
            return await FindByCondition(Contact => Contact.ContactId.Equals(ContactId))
                .FirstOrDefaultAsync();
        }
        public async Task<Contact> GetContactWithDetailsAsync(Guid ContactId)
        {
            return await FindByCondition(Contact => Contact.ContactId.Equals(ContactId))
                .Include(ac => ac.Company)
                .FirstOrDefaultAsync();
        }
        public void CreateContact(Contact Contact)
        {
            Create(Contact);
        }
        public void UpdateContact(Contact Contact)
        {
            Update(Contact);
        }
        public void DeleteContact(Contact Contact)
        {
            Delete(Contact);
        }
    }
}
