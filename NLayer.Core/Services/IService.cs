using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        //repo dan alınan kodlar burada işlenebilir
        //bussines işlemler burada gerçekleşir
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);




    }
}
