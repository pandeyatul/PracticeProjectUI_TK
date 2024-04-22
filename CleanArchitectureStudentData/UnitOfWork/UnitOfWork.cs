using CleanArchitectureStudentData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudentData.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepo<T> genericRepo<T>() where T : class
        {
            IGenericRepo<T> repository=new GenericRepository<T>(_context);
            return repository;
        }

        public void Save()
        {
           _context.SaveChanges();
        }
        #region
        private bool disposed = false;
        protected bool Dispose(bool disposing)
        {
            if (!disposing)
            {
                _context.Dispose();
            }
            return disposed=true;
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
