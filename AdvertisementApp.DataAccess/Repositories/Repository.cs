using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T>:IRepository<T> where T : BaseEntity
    {
        private readonly AdvertisementAppContext _context;

        public Repository(AdvertisementAppContext context)
        {
            _context = context;
        }
        //bütün veriyi getirme
        //bütün veriyi sıralayarak getirme 
        //bütün veriyi filitreleyerek getirme
        //asnotracking()
        public async Task<List<T>> GetAllAsync() //bir method asyn ise sonuna asyn eklmeyi unutma //bütün listeyi getirdik
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        //Filtrelemek
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        //Sıralamak
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector,OrderByType orderByType= OrderByType.DESC)
        {
            return orderByType==OrderByType.ASC? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync():await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        //Filtreli ve sıralı

        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter,Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
        }
        public async Task<T>FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking?await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter):await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task CreateAsync(T enitiy)
        {
            await _context.Set<T>().AddAsync(enitiy);
        }

        public void Update(T entity,T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }

       
        
    }
}
