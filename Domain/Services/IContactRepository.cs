using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal interface IContactRepository 
    {
        Task CreateAsync(Contact country);
        Task<List<Contact>> GetCompanyAsync(bool asNoTracking = false);
        Task DeleteAsync(int id);
    }
}
