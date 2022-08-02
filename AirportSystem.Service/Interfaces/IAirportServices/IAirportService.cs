using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Service.DTO_s.Airports;

namespace AirportSystem.Service.Interfaces
{
    public interface IAirportService
    {
        Task<Airport> CreateAsync(AirportForCreation airportForCreation);
        Task<Airport> UpdateAsync(long id, AirportForCreation airplaneForCreation);
        Task<bool> DeleteAsync(Expression<Func<Airplane, bool>> expression);
        Task<IEnumerable<Airport>> GetAllAsync(Expression<Func<Airport, bool>> expression = null);
        Task<Airport> GetAsync(Expression<Func<Airport, bool>> expression);
    }
}