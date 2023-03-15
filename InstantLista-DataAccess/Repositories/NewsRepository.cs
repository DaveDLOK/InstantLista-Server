using InstantLista_DataAccess;
using InstantLista_DataAccess.Interfaces;
using InstantLista_ClassLibrary;

namespace InstantLista_DataAccess.Repositories;

public class NewsRepository : BaseRepository<News>, INewsRepository
{
    InstantListaDBContext _dbContext;

    public NewsRepository(InstantListaDBContext context):base(context)
    {
        _dbContext = context;
    }

}