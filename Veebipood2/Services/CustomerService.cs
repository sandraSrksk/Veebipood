using Veebipood2.Data;
using Veebipood2.Models;
using Microsoft.EntityFrameworkCore;

namespace Veebipood2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Veebipood2Context _context;
        public CustomerService(Veebipood2Context context) 
        {
            _context = context;
        }
        public async Task<PagedResult<Customer>> List(int page, int pageSize)
        {
            var result = await _context.Customer.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Customer Customer)
        {
            if (Customer.Id == 0)
            {
                _context.Add(Customer);
            }
            else
            {
                _context.Update(Customer);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
            }

            await _context.SaveChangesAsync();
        }

        public bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

