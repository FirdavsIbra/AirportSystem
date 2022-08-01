using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.RouleTables;

namespace AirportSystem.Data.Repositories
{
    public class RouleTableRepository : GenericRepository<RouleTable>, IRouleTableRepository
    {
        public RouleTableRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
