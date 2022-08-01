using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.Airplanes;

namespace AirportSystem.Data.Repositories
{
    public class AirplaneRepository : GenericRepository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
