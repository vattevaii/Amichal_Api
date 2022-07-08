using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amichal.Domain.Entities.UserRoles;
namespace Amichal.Application.Common.Interfaces.Services.Persistence.Users;

public interface IAdmin: IUserRepository<Admin>
{
}
