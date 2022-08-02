using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories;
using AirportSystem.Data.IRepositories.IAirplaneRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.CommonRepo
{
#pragma warning disable
    public class UnitOfWork : IUnitOfWork
    {
        public IAirplaneRepository Airplanes { get; }

        public IAirportAirplaneRepository AirportAirplanes { get; }

        public IAirportRepository Airports { get; }

        public IBlackListRepository BlackLists { get; }

        public ITicketRepository Tickets { get; }

        public IRouleTableRepository RouleTables { get; }

        public IEmployeeRepository Employees { get; }

        public IOrderRepository Orders { get; }

        public IPassengerRepository Passengers { get; }

        public IPaymentRepository Payments { get; }

        private readonly AirportSystemDbContext dbContext;

        public UnitOfWork(AirportSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
            Payments = new PaymentRepository(dbContext);
            Passengers = new PassengerRepository(dbContext);
            Orders = new OrderRepository(dbContext);
            Employees = new EmployeeRepository(dbContext);
            RouleTables = new RouleTableRepository(dbContext);
            Tickets = new TicketRepository(dbContext);
            BlackLists = new BlackListRepository(dbContext);
            Airports = new AirportRepository(dbContext);
            Airplanes = new AirplaneRepository(dbContext);
            AirportAirplanes = new AirportAirplaneRepository(dbContext);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
