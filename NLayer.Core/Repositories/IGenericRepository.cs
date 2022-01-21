using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    //veritabanına yapılması gerçekleştirilecek ortak sorgular burada gerçekleştirilir
    //ekleme silme güncelleme
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync (int id);

        //veritabanına yapılacak olan sorguyu oluşturdum.
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        //IQueryable where ifadesinden sonra ordeyby ı da alır bana direk olarak sıralar.
        Task<bool>AnyAsync(Expression<Func<T, bool>> expression);

        Task AddRangeAsync (IEnumerable<T> entities);
        Task AddAsync (T entity);
        void Update (T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);



    }
}
