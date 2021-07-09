using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Save();

        Task SaveAsync();
  }
}
