using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Service.DTO_s.Passengers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IPassengerService
    {
        Task<Passenger> CreateAsync(PassengerForCreation passengerForCreation);
        Task<Passenger> UpdateAsync(long id, PassengerForCreation passengerForCreation);
        Task<bool> DeleteAsync(Expression<Func<Passenger, bool>> expression);
        Task<IEnumerable<Passenger>> GetAllAsync(PaginationParams @params, Expression<Func<Passenger, bool>> expression = null);
        Task<Passenger> GetAsync(Expression<Func<Passenger, bool>> expression);
    }
}