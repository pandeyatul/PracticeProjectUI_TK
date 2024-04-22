using Entities_TK.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PracticeProjectUI_TK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TK_Repository
{
    //states of Entity:-
    //Attach
    //Detach
    //Modified
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;

        public GenericRepo(ApplicationDbContext context, DbSet<T> dbset = null)
        {
            _context = context;
            _dbset = dbset;
        }

        public async Task Create(T entites)
        {
            await _dbset.AddAsync(entites);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entities)
        {
            _dbset.Remove(entities);
            await _context.SaveChangesAsync();
        }

        public async void DeleteRange(List<T> entites)
        {
            _dbset.RemoveRange(entites);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>>? GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
            bool dissabledTracking = true)
        {
            IQueryable<T> query = _dbset;
            if (dissabledTracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include!=null)
            {
                query = include(query);
            }
            if (orderBy!=null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByid(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool dissabledTracking = true)
        {
            IQueryable<T> query = _dbset;
            if (dissabledTracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task Update(T country)
        {
            _dbset.Attach(country);
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
