﻿using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Orders;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class OrderService : IOrderService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateAsync(OrderForCreation orderForCreation)
        {
            var exist = await unitOfWork.Orders.GetAsync(prop => prop.PassengerId == orderForCreation.PassengerId);

            if (exist is not null)
                throw new Exception("This Order already exists!");

            var mappedOrder = mapper.Map<Order>(orderForCreation);

            mappedOrder.Created();

            var result = await unitOfWork.Orders.CreateAsync(mappedOrder);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var exist = await unitOfWork.Orders.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Order not found!");

            exist.Deleted();

            await unitOfWork.Orders.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
        {
            var exist = unitOfWork.Orders.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Orders not found");

            return exist;
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var exist = await unitOfWork.Orders.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Order not found!");

            return exist;
        }

        public async Task<Order> UpdateAsync(long id, OrderForCreation orderForCreation)
        {
            var exist = await unitOfWork.Orders.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Order not found!");

            exist = mapper.Map(orderForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Orders.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}