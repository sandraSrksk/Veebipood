using Veebipood2.Data;
using Microsoft.EntityFrameworkCore;

namespace Veebipood2.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly Veebipood2Context _context;

        public ProductTypeService(Veebipood2Context context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductType>> List(int page, int pageSize)
        {
            var result = await _context.ProductTypes.GetPagedAsync(page, pageSize);
            return result;
        }

        public async Task<ProductType> GetById(int id)
        {
            var result = await _context.ProductTypes.FirstOrDefaultAsync(m => m.Id == id);
            return result;
        }

        public async Task Save(ProductType productType)
        {
            if (productType.Id == 0)
            {
                _context.Add(productType);
            }
            else
            {
                _context.Update(productType);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
            }

            await _context.SaveChangesAsync();
        }

        public bool ProductTypeExists(int id)
        {
            return (_context.ProductTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<LookupItem>> Lookup()
        {
            var result = await _context.ProductTypes
                .OrderBy(ProductType => ProductType.TypeName)
                .Select(ProductType => new LookupItem
                {
                    Id= ProductType.Id,
                    TypeName= ProductType.TypeName,
                })
                .ToListAsync();
            return result;
        }
    }
}

