using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAirplaneRepository Airplanes { get; }
        IAirportAirplaneRepository AirportAirplanes { get; }
        IAirportRepository Airports { get; }
        IBlackListRepository BlackLists { get; }
        ITicketRepository Tickets { get; }
        IRouleTableRepository RouleTables { get; }
        IEmployeeRepository Employees { get; }
        IOrderRepository Orders { get; }
        IPassengerRepository Passengers { get; }
        IPaymentRepository Payments { get; }

        Task SaveChangesAsync();

    }
}
