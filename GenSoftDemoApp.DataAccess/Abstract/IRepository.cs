using GenSoftDemoApp.Entity;
using System.Linq.Expressions;
using System.Net;

namespace GenSoftDemoApp.DataAccess.Abstract
{
    public interface IRepository<T> where T : EntityBase
    {
        Task <List<T>> GetList();

        Task<T> GetByFilter(Expression<Func<T, bool>> predicate);

        Task<T> GetById(int id);

        Task<HttpStatusCode> Create(T entity);

        Task<HttpStatusCode> Update(T entity);

        Task<HttpStatusCode> Delete(int id);

        Task<int> Count();

        Task<int> FilteredCount(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetFilteredList(Expression<Func<T, bool>> predicate);
    }
}
