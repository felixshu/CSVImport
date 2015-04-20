using System.Linq;
using Domian.Entity;

namespace Domian.Abstract
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> CustomerRepository { get; }  
    }
}