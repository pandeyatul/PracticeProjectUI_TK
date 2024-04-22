using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Repository
{
    public interface IGenericRepo<T>:IDisposable
    {
         IEnumerable<T> GetAll(Expression<Func<T ,bool>>filter=null,Func<IQueryable<T>,IOrderedQueryable<T>> orderby=null,string IncludeProerties="");
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Add(T item);
        Task<T> AddAsync(T item);
        void DeletebyId(object id);
        void Delete(T Entity);
        Task<T> DeleteAsync(T Entity);
        void Update(T item);
        Task<T> UpdateAsync(T item);
    }
}
