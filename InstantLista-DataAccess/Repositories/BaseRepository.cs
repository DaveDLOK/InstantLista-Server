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

	}
}

