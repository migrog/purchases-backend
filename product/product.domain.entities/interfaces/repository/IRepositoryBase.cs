using System;
using System.Collections.Generic;
using System.Text;

namespace product.domain.entities.interfaces.repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);
        void Delete(IEnumerable<T> lista);

        T Select(int id);

        T Select(string id);

        IList<T> Select();
    }
}
