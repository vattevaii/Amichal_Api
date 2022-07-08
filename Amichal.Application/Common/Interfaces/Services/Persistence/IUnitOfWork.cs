using Amichal.Application.Common.Interfaces.Services.Persistence.Users;
using Amichal.Domain.Entities;
using Amichal.Domain.Entities.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amichal.Application.Common.Interfaces.Services.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository<Admin> Admins { get; }
        IProductRepository Product { get; }
        IUserRepository<Customer> Customers { get; }
        IUserRepository<User> Users { get; }
        IUserRepository<Seller> Sellers { get; }
        IUserRepository<GroupAdmin> GroupAdmins { get; }
        void Save();
    }
}
