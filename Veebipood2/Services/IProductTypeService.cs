using Veebipood2.Data;

namespace Veebipood2.Services
{
    public interface IProductTypeService
    {
        Task<PagedResult<ProductType>> List(int page, int pageSize);
        Task<ProductType> GetById(int id);
        Task Save(ProductType ProductType);
        Task Delete(int id);

        Task<IEnumerable<LookupItem>> Lookup();
    }
}

