using InstantLista_DataAccess;
using InstantLista_DataAccess.Interfaces;
using InstantLista_ClassLibrary;

namespace InstantLista_DataAccess.Repositories;

public class MembershipRepository : BaseRepository<Membership>, IMembershipRepository
{
    InstantListaDBContext _dbContext;

    public MembershipRepository(InstantListaDBContext context):base(context)
    {
        _dbContext = context;
    }

}