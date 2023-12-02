
using Application.Repository;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
namespace Infrastructure.Repositories
{
    public class ProcessRequstRepository : BaseRepository<ProcessRequest>,IProcessRequstRepository
    {

        public ProcessRequstRepository(AppDbContext dbContext) : base(dbContext)
        {
            /*
                This is the place where we create the logic for query,
                for saving and calling data for that entity.
             */
        }
    }
}
