﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task Create(T entity);
        void Update(T entity);
        void Remove(Object id);
        IQueryable<T> GetQuery();
    }
}
