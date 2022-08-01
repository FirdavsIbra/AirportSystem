using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.Airports;

namespace AirportSystem.Data.Repositories
{
    public class AirportAirplaneRepository : GenericRepository<AirportAirplane>, IAirportAirplaneRepository
    {
        public AirportAirplaneRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
