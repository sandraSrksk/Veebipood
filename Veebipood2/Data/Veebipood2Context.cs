using Microsoft.EntityFrameworkCore;

namespace Veebipood2.Data
{
    public class Veebipood2Context : DbContext
    {
        public Veebipood2Context (DbContextOptions<Veebipood2Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<ProductType> ProductTypes { get; set; } = default!;

        public DbSet<Customer> Customer { get; set; } = default!;

        public DbSet<Invoice> Invoices { get; set; } = default!;
    }
}
