using System.Data.Entity;
using Domian.Entity;

namespace Domian.Concrete
{
    public class CsvImportDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}