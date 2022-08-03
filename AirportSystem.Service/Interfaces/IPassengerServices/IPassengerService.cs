using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Service.DTO_s.Passengers;

namespace AirportSystem.Service.Interfaces.IPassengerServices
{
    public interface IPassengerService
    {
        Task<Passenger> CreateAsync(PassengerForCreation passengerForCreation);
        Task<Passenger> UpdateAsync(long id, PassengerForCreation passengerForCreation);
        Task<bool> DeleteAsync(Expression<Func<Passenger, bool>> expression);
        Task<IEnumerable<Passenger>> GetAllAsync(PaginationParams @params = null, Expression<Func<Passenger, bool>> expression = null);
        Task<Passenger> GetAsync(Expression<Func<Passenger, bool>> expression);
        Task<bool> CheckLoginAsync(string username, string password);
        Task<Passenger> ChangePasswordAsync(PassangerForChangePassword forChangePassword);
    }
}