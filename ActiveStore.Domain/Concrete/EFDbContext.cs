using ActiveStore.Domain.Entities;
using System.Data.Entity;


namespace ActiveStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
