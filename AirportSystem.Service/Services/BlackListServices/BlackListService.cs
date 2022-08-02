﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.BlackLists;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.BlackLists;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AutoMapper;

namespace AirportSystem.Service.Services.BlackListServices
{
    public class BlackListService : IBlackListService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BlackListService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BlackList> CreateAsync(BlackListForCreation blackListForCreation)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(a => a.PassengerId == blackListForCreation.PassengerId);

            if (exist is not null)
                throw new Exception("This blacklist already exists!");

            var mappedAirport = mapper.Map<BlackList>(exist);

            mappedAirport.Created();

            var result = await unitOfWork.BlackLists.CreateAsync(mappedAirport);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<BlackList> UpdateAsync(long id, BlackListForCreation blackListForCreation)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This blacklist not found!");

            exist = mapper.Map(blackListForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.BlackLists.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<BlackList, bool>> expression)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(expression);

            if (exist is null)
                throw new Exception("This blacklist not found!");

            exist.Deleted();

            await unitOfWork.BlackLists.DeleteAsync(expression);

            return true;

        }

        public Task<IEnumerable<BlackList>> GetAllAsync(PaginationParams @params, Expression<Func<BlackList, bool>> expression = null)
        {
            var exist = unitOfWork.BlackLists.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("blacklists not found");

            return Task.FromResult<IEnumerable<BlackList>>(exist);
        }

        public async Task<BlackList> GetAsync(Expression<Func<BlackList, bool>> expression)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This blacklist not found!");

            return exist;
        }
    }
}