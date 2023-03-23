using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace InstantLista_DataAccess.Repositories
{
	public abstract class BaseRepository<T> where T : class
	{
		InstantListaDBContext _dbContext;

		public BaseRepository(InstantListaDBContext context)
		{
			_dbContext = context;
		}

		public async Task<IEnumerable<T>> readAll(Expression<Func<T,bool>> expression)
		{
			var result =  await _dbContext.Set<T>().Where(expression).ToListAsync();
			return result;
		}

		public async Task<T> Update(T entity)
		{
			 _dbContext.Update(entity);

			await _dbContext.SaveChangesAsync();

			return entity;
		}

        public async Task<T> Create(T entity)
        {
            await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}

