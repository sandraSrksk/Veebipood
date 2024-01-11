using Veebipood2.Data;
using Veebipood2.Models;

namespace Veebipood2.Services
{
    public interface IInvoiceService
    {
        Task<PagedResult<Invoice>> List(int page, int pageSize);
        Task<Invoice> GetById(int id);
        Task Save(Invoice Invoice);
        Task Delete(int id);
        bool InvoiceExists(int id);
    }
}