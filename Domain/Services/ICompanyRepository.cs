using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICompanyRepository
    {
        Task CreateAsync(Company company);
        Task<List<Company>> GetCompanyAsync(bool asNoTracking = false);
        Task DeleteAsync(int id);
    }
}
