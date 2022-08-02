﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Airports;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;

namespace AirportSystem.Service.Services.AirportServices
{
    public class AirportService : IAirportService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AirportService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
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

        public async Task<Airport> UpdateAsync(long id, AirportForCreation airportForCreation)
        {
            var exist = await unitOfWork.Airports.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This airport not found!");

            exist = mapper.Map(airportForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Airports.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Airport, bool>> expression)
        {
            var exist = await unitOfWork.Airports.GetAsync(expression);

            if (exist is null)
                throw new Exception("This airport not found!");

            exist.Deleted();

            await unitOfWork.Airports.DeleteAsync(expression);

            return true;
        }

        public Task<IEnumerable<Airport>> GetAllAsync(PaginationParams @params, Expression<Func<Airport, bool>> expression = null)
        {
            var exist = unitOfWork.Airports.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Airplanes not found");

            return Task.FromResult<IEnumerable<Airport>>(exist);
        }


        public async Task<Airport> GetAsync(Expression<Func<Airport, bool>> expression)
        {
            var exist = await unitOfWork.Airports.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This airport not found!");

            return exist;
        }
    }
}