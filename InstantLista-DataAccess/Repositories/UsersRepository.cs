using InstantLista_DataAccess;
using InstantLista_DataAccess.Interfaces;
using InstantLista_ClassLibrary;

namespace InstantLista_DataAccess.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    InstantListaDBContext _dbContext;

    public UsersRepository(InstantListaDBContext context):base(context)
    {
        _dbContext = context;
    }

}