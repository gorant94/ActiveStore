using System.Collections.Generic;
using ActiveStore.Domain.Entities;
using ActiveStore.Domain.Abstract;

namespace ActiveStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}