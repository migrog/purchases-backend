using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace user.domain.entities.interfaces.services
{
    public interface IServiceBase<T> where T : EntityBase
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        void Delete(IEnumerable<T> lista);

        T Get(int id);

        T Get(string id);

        IList<T> Get();
    }
}
