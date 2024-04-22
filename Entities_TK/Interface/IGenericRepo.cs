using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface IGenericRepo<T> where T: class
    {
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter,Func<IQueryable<T>,IOrderedQueryable<T>>orderBy,
            Func<IQueryable<T>,IIncludableQueryable<T,object>>include,bool dissabledTracking=true
            );
        public Task<T> GetByid(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool dissabledTracking = true);
        public Task Create(T entities);
        public Task Update(T entities);
        public Task Delete(T entities);
        public void DeleteRange(List<T> entites);

    }
}
