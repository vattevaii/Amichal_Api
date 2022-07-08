using Amichal.Domain.Entities.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amichal.Application.Common.Interfaces.Services.Persistence.Users
{
    public interface ISeller: IUserRepository<Seller>
    {
        void Add(Seller entity);
    }
}
