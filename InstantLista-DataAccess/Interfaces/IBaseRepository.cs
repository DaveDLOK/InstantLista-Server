using System;
using InstantLista_DataAccess.Repositories;
namespace InstantLista_DataAccess.Interfaces;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> readAll();
}


