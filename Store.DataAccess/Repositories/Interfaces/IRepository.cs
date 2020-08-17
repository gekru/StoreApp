using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
