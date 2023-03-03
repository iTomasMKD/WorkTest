using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal interface ICountryRepository
    {
        Task CreateAsync(Country country);
        Task<List<Country>> GetCompanyAsync(bool asNoTracking = false);
        Task DeleteAsync(int id);
    }
}
