using Microsoft.EntityFrameworkCore;

namespace Veebipood2.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(Veebipood2Context context) : base(context)
        {
        }

        public override async Task<PagedResult<Product>> List(int page, int pageSize)
        {
            var result = await Context.Products.Include(item => item.ProductType).GetPagedAsync(page, pageSize);

            return result;
        }

        public override async Task<Product> GetById(int id)
        {
            var result = await Context.Products.Include(item => item.ProductType)
                                                .FirstOrDefaultAsync();

            return result;
        }
    }
}
