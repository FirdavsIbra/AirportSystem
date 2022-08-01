using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.Orders;

namespace AirportSystem.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AirportSystemDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
