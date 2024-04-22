using CleanArchitectureStudentData.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.Repository
{
    public class GenericRepository<T> : IDisposable, IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public async Task<T> AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            return item;
        }

        public void Delete(T Entity)
        {
            if (_context.Entry(Entity).State==EntityState.Detached)
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
        }

        public async Task<T> DeleteAsync(T Entity)
        {
            if (_context.Entry(Entity).State==EntityState.Detached)
            {
                _dbSet.Attach(Entity);
            }
             _dbSet.Remove(Entity);
            return Entity;
        }

        public void DeletebyId(object id)
        {
            T entityTodelete = _dbSet.Find(id);
            if (entityTodelete != null)
            {
                Delete(entityTodelete);
            }
        }
        #region IdisposableMember
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed=true;
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string IncludeProerties = "")
        {
            IQueryable<T> Query = _dbSet;
            if (filter!=null)
            {
                Query= Query.Where(filter);
            }
            foreach (var includproperty in IncludeProerties.Split(new char[]{',' },StringSplitOptions.RemoveEmptyEntries))
            {
                Query = Query.Include(includproperty);
            }
            if (orderby != null)
            {
                return orderby(Query).ToList();
            }
            else
            {
                return Query.ToList();
            }
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
