using CurrencyWallet.Application.Contract.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly CurrencyWalletDbContext _dbContext;

        public BaseRepository(CurrencyWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T Entity)
        {
           await  _dbContext.Set<T>().AddAsync(Entity);
           await  _dbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
          return  await _dbContext.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetById(string Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetPagedResponse(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
             _dbContext.Entry(Entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
