using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Passengers;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class PassengerService : IPassengerService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PassengerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Passenger> CreateAsync(PassengerForCreation passengerForCreation)
        {
            var exist = await unitOfWork.Passengers.GetAsync(a => a.PassportNumber == passengerForCreation.PassportNumber);

            if (exist is not null)
                throw new Exception("This Passenger already exists!");

            var mappedPassenger = mapper.Map<Passenger>(passengerForCreation);

            mappedPassenger.Created();

            var result = await unitOfWork.Passengers.CreateAsync(mappedPassenger);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Passenger, bool>> expression)
        {
            var exist = await unitOfWork.Passengers.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Passenger not found!");

            exist.Deleted();

            await unitOfWork.Passengers.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Passenger>> GetAllAsync(PaginationParams @params, Expression<Func<Passenger, bool>> expression = null)
        {
            var exist = unitOfWork.Passengers.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Passengers not found");

            return exist;
        }

        public async Task<Passenger> GetAsync(Expression<Func<Passenger, bool>> expression)
        {
            var exist = await unitOfWork.Passengers.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Passenger not found!");

            return exist;
        }

        public async Task<Passenger> UpdateAsync(long id, PassengerForCreation passengerForCreation)
        {
            var exist = await unitOfWork.Passengers.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Passenger not found!");

            exist = mapper.Map(passengerForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Passengers.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}