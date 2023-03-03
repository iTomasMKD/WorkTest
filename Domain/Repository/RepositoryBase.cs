using Data.ApplicationDbContext;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly TestDbContext context;

        public RepositoryBase(TestDbContext repositoryContext)
        {
            context  = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
