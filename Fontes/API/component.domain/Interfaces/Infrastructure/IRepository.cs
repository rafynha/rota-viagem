using System.Collections.Generic;

namespace component.domain.Interfaces.Infrastructure
{
    public interface IRepository<T> where T : class
    {
         int? Create(T entity);
        IEnumerable<T> GeatAll();
        void Delete(int id);
        T GetByID(int id);
        T GetByName(string name);
        int? Update(T entity);
    }
}