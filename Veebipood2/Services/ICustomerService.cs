using Veebipood2.Data;
using Veebipood2.Models;

namespace Veebipood2.Services
{
    public interface ICustomerService
    {
        Task<PagedResult<Customer>> List(int page, int pageSize);
        Task<Customer> GetById(int id);
        Task Save(Customer Customer);
        Task Delete(int id);
        bool CustomerExists(int id);
    }
}
