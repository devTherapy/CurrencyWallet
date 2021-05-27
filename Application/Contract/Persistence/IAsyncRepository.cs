using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Contract.Persistence
{
    public  interface IAsyncRepository<T> where T : class
    {
        Task<T> GetById(string Id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task<IReadOnlyList<T>> GetPagedResponse(int page, int size);
    }
}
