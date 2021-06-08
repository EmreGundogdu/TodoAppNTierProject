using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.Interfaces;
using TodoAppNTier.DataAccess.Repositories;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
