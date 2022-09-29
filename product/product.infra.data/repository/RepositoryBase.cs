using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using product.domain.entities;
using product.domain.entities.interfaces.repository;
using product.infra.data.context;

namespace product.infra.data.repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected purchasesContext context = new purchasesContext();

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public void Delete(IEnumerable<T> lista)
        {
            context.Set<T>().RemoveRange(lista);
            context.SaveChanges();
        }


        public IList<T> Select()
        {
            return context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Select(string id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
