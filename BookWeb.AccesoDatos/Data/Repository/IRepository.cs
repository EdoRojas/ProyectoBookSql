using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //recibir id
        T Get(int id);

        //listaque trae todo
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Primero o defecto
        T GetFirsOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        //Agregar por entidad
        void Add(T entity);

        //remover por identificador
        void Remove(int id);

        //Remover por entidad
        void Remove(T entity);

    }
}
