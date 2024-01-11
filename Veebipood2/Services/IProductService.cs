using Veebipood2.Data;
using Veebipood2.Data.Queries;

namespace Veebipood2.Services
{
    public interface IProductService
    {
        Task<PagedResult<Product>> List(int page, int pageSize, ProductQuery query = null);
        Task<Product> GetById(int id);
        Task Save(Product product);
        Task Delete(int id);
    }
}

