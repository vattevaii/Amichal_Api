using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Domain.Entities;

namespace Amichal.Infrastructure.Persistence
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context):base(context)
        {
            _context = context;
        }
    }
}
