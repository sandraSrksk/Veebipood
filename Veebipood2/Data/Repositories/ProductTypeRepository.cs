using Microsoft.EntityFrameworkCore;

namespace Veebipood2.Data.Repositories
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(Veebipood2Context context) : base(context)
        {
        }

        /*
         *  Q U E R I E S
         */
        public async Task<IEnumerable<LookupItem>> Lookup()
        {
            var result = await Context.ProductTypes
                                       .OrderBy(productType => productType.TypeName)
                                       .Select(productType => new LookupItem
                                       {
                                           Id = productType.Id,
                                           TypeName = productType.TypeName
                                       })
                                       .ToListAsync();
            return result;
        }
    }
}
