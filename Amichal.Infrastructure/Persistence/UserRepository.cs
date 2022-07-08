using Amichal.Application.Common.Interfaces.Services.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amichal.Infrastructure.Persistence
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private DbSet<T> _dbSet;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetT(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate)?.FirstOrDefault();
        }
    }
}
