using Veebipood2.Data;
using Microsoft.EntityFrameworkCore;
using Veebipood2.Data.Queries;

namespace Veebipood2.Services
{
    public class ProductService : IProductService
    {
        private readonly Veebipood2Context _context;

        public ProductService(Veebipood2Context context)
        {
            _context = context;
        }

        public async Task<PagedResult<Product>> List(int page, int pageSize, ProductQuery query = null)
        {
            IQueryable<Product> dbQuery = _context.Products.Include(t => t.ProductType);
            query = query ?? new ProductQuery();

            if(query.TypeId != null)
            {
                dbQuery = dbQuery.Where(product => product.ProductTypeId == query.TypeId);
            }

            if (!string.IsNullOrWhiteSpace(query.ProductSearch))
            {
                dbQuery = dbQuery.Where(product => product.Name.Contains(query.ProductSearch) ||
                                                   product.Description.Contains(query.ProductSearch));
            }

            var result = await dbQuery.GetPagedAsync(page, pageSize);
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Include(t => t.ProductType).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(Product product)
        {
            if (product.Id == 0)
            {
                _context.AddAsync(product);
            }
            else
            {
                _context.Update(product);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            if (product == null)
            {
                return;
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

