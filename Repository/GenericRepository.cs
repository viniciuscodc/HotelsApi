using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelsApi.IRepository;
using HotelsApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelsApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        
        public async Task<IList<T>> GetAll (Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if(expression != null){
                query = query.Where(expression);
            }

            if(orderBy != null){
                query = orderBy(query);
            }

            if (includes != null){
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            
            return await query.AsNoTracking().ToListAsync();
        }
         public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
         {
            IQueryable<T> query = _db;
            if (includes != null){
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T entity) 
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        
    }
}