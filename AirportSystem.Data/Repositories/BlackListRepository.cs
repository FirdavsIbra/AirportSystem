using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.BlackLists;

namespace AirportSystem.Data.Repositories
{
    public class BlackListRepository : GenericRepository<BlackList>, IBlackListRepository
    {
        public BlackListRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
