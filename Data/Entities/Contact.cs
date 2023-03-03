using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public ICollection<Company> Company { get; set; }
        public ICollection<Country> Country { get; set; }
    }
}
