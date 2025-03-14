using System.Linq.Expressions;

namespace Api.ClinicaMedica.DataAccess.Interfaces
{
    public interface IRepositoryAsync<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(object? id);
        Task<T> GetById(int? id, params Expression<Func<T, object>>[] includes);
        Task<bool> ExistById(object? id);
        Task<T> Insert(T entity);
        Task<T> Delete(object id);
        Task Update(T entity);
    }
}
