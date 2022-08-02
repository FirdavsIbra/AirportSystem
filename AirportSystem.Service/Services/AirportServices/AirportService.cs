using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Service.DTO_s.Airports;
using AirportSystem.Service.Interfaces;
using AutoMapper;

namespace AirportSystem.Service.Services
{
    public class AirportService : IAirportService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AirportService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
     
        
        public async Task<Airport> CreateAsync(AirportForCreation airportForCreation)
        {
            var exist = await unitOfWork.Airports.GetAsync(a => a.Name == airportForCreation.Name);

            if (exist is not null)
                throw new Exception("This airport already exists!");

            var mappedAirport = mapper.Map<Airport>(exist);

            mappedAirport.Created();

            var result = await unitOfWork.Airports.CreateAsync(mappedAirport);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public Task<Airport> UpdateAsync(long id, AirportForCreation airplaneForCreation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<Airplane, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Airport>> GetAllAsync(Expression<Func<Airport, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Airport> GetAsync(Expression<Func<Airport, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}