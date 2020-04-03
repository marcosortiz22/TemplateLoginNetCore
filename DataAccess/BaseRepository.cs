using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public T Get(int id) => _context.Set<T>().Find(id);

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public List<T> GetAll() => _context.Set<T>().ToList();

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public T Find(Expression<Func<T, bool>> match) => _context.Set<T>().SingleOrDefault(match);

        public async Task<T> FindAsync(Expression<Func<T, bool>> match) => await _context.Set<T>().SingleOrDefaultAsync(match);

        public List<T> FindAll(Expression<Func<T, bool>> match) => _context.Set<T>().Where(match).ToList();

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match) => await _context.Set<T>().Where(match).ToListAsync();
        
        public T Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        public async Task<T> AddAsync(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public IEnumerable<T> AddAll(IEnumerable<T> tList)
        {
            _context.Set<T>().AddRange(tList);
            _context.SaveChanges();
            return tList;
        }

        public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList)
        {
            _context.Set<T>().AddRange(tList);
            await _context.SaveChangesAsync();
            return tList;
        }

        public T Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = _context.Set<T>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                _context.SaveChanges();
            }
            return existing;
        }

        public async Task<T> UpdateAsync(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = await _context.Set<T>().FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T t)
        {
            _context.Set<T>().Remove(t);
            return await _context.SaveChangesAsync();
        }

        public int Count() => _context.Set<T>().Count();

        public int Count(Expression<Func<T, bool>> match) => _context.Set<T>().Count(match);

        public async Task<int> CountAsync() => await _context.Set<T>().CountAsync();
    }
}
