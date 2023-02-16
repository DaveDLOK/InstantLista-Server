using System;
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

		public async Task<IEnumerable<T>> readAll()
		{
			var result =  await _dbContext.Set<T>().ToListAsync();
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

