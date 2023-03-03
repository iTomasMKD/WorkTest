using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    internal interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        IContactRepository Contact { get; }
        ICountryRepository Country{ get; }
        Task SaveAsync();
    }
}
