using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.Repository
{
    public interface IRepository
    {
        IEnumerable<T> SelectAll<T>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null) where T: class;
        Task<T> SelectById<T>(int id) where T : class;
        Task<T> SelectById<T>(string id) where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
