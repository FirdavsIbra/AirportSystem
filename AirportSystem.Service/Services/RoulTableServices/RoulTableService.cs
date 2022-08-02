using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.RoulTable;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class RoulTableService : IRoulTableService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RoulTableService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<RouleTable> CreateAsync(RoulTableForCreation rouleTableForCreation)
        {
            var mappedRouleTable = mapper.Map<RouleTable>(rouleTableForCreation);

            mappedRouleTable.Created();

            var result = await unitOfWork.RouleTables.CreateAsync(mappedRouleTable);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<RouleTable, bool>> expression)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(expression);

            if (exist is null)
                throw new Exception("This RouleTable not found!");

            exist.Deleted();

            await unitOfWork.RouleTables.DeleteAsync(expression);

            return true;
        }

        public Task<IEnumerable<RouleTable>> GetAllAsync(PaginationParams @params, Expression<Func<RouleTable, bool>> expression = null)
        {
            var exist = unitOfWork.RouleTables.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("RouleTables not found");

            return Task.FromResult<IEnumerable<RouleTable>>(exist);
        }

        public async Task<RouleTable> GetAsync(Expression<Func<RouleTable, bool>> expression)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This RouleTable not found!");

            return exist;
        }

        public async Task<RouleTable> UpdateAsync(long id, RoulTableForCreation rouleTableForCreation)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This RouleTable not found!");

            exist = mapper.Map(rouleTableForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.RouleTables.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}