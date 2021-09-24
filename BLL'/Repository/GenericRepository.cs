using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.Repository
{
    public class Repository<Car_RentalDbContext> : IRepository where Car_RentalDbContext : DbContext
    {
        protected Car_RentalDbContext dbContext;


        public Repository(Car_RentalDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> SelectAll<T>(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null) where T : class
        {
            DbSet<T> dbSet = dbContext.Set<T>();
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public async Task<T> SelectById<T>(int id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> SelectById<T>(string id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}
