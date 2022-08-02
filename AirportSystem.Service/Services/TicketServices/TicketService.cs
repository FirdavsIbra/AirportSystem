﻿using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Tickets;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Tickets;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public TicketService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Ticket> CreateAsync(TicketForCreation ticketForCreation)
        {
            var mappedTicket = mapper.Map<Ticket>(ticketForCreation);

            mappedTicket.Created();

            var result = await unitOfWork.Tickets.CreateAsync(mappedTicket);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Ticket, bool>> expression)
        {
            var exist = await unitOfWork.Tickets.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Ticket not found!");

            exist.Deleted();

            await unitOfWork.Tickets.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync(PaginationParams @params, Expression<Func<Ticket, bool>> expression = null)
        {
            var exist = unitOfWork.Tickets.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Tickets not found");

            return exist;
        }

        public async Task<Ticket> GetAsync(Expression<Func<Ticket, bool>> expression)
        {
            var exist = await unitOfWork.Tickets.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Ticket not found!");

            return exist;
        }

        public async Task<Ticket> UpdateAsync(long id, TicketForCreation ticketForCreation)
        {
            var exist = await unitOfWork.Tickets.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Ticket not found!");

            exist = mapper.Map(ticketForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Tickets.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}