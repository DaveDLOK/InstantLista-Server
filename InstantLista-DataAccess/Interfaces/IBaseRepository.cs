using System;
using System.Linq.Expressions;
using InstantLista_DataAccess.Repositories;
namespace InstantLista_DataAccess.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> readAll(Expression<Func<T,bool>> expression);

    Task<T> Update(T entity);

    Task<T> Create(T entity);
}


