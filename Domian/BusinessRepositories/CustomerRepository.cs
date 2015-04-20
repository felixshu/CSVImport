using System.Linq;
using Domian.Abstract;
using Domian.Concrete;
using Domian.Entity;

namespace Domian.BusinessRepositories
{
    public class EfCustomerRepository:ICustomerRepository
    {
        private readonly CsvImportDbContext _context = new CsvImportDbContext();

        public IQueryable<Customer> CustomerRepository
        {
            get { return _context.Customers; }
        }
    }
}