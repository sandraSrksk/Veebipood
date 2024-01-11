namespace Veebipood2.Data.Repositories
{
    public interface IProductTypeRepository
    {
        Task<PagedResult<ProductType>> List(int page, int pageSize);
        Task<ProductType> GetById(int id);
        Task Save(ProductType list);
        Task Delete(int id);
        Task<IEnumerable<LookupItem>> Lookup();
    }
}
