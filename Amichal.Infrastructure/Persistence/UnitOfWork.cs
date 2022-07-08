using Amichal.Application.Common.Interfaces.Services.Persistence;
using Amichal.Application.Common.Interfaces.Services.Persistence.Users;
using Amichal.Domain.Entities;
using Amichal.Domain.Entities.UserRoles;

namespace Amichal.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context;
        public IUserRepository<Admin> Admins{get;private set;}

        //public IProductRepository Product { get; private set; };

        public IUserRepository<Customer> Customers { get; private set; }

        public IProductRepository Product { get; private set; }

        public IUserRepository<User> Users { get; private set; }

        public IUserRepository<Seller> Sellers { get; private set; }
        public IUserRepository<GroupAdmin> GroupAdmins { get; private set; }


        public UnitOfWork(DatabaseContext context)
        {
            _context=context;
            Admins = new UserRepository<Admin>(context: _context);
            Customers = new UserRepository<Customer>(_context);
            Users = new UserRepository<User>(_context);
            Sellers = new UserRepository<Seller>(_context);
            GroupAdmins = new UserRepository<GroupAdmin>(_context);

            Product = new ProductRepository(context: _context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
