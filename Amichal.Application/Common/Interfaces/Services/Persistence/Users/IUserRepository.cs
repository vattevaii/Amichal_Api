using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amichal.Application.Common.Interfaces.Services.Persistence.Users;

public interface IUserRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetT(Expression<Func<T, bool>> predicate);
    //void Edit(T entity);
    bool Exists(Expression<Func<T, bool>> predicate);
}
