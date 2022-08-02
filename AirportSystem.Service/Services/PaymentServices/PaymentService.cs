using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Payments;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PaymentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Payment> CreateAsync(PaymentForCreation paymentForCreation)
        {
            var exist = await unitOfWork.Payments.GetAsync(a => a.OrderId == paymentForCreation.OrderId);

            if (exist is not null)
                throw new Exception("This Payment already exists!");

            var mappedPayment = mapper.Map<Payment>(paymentForCreation);

            mappedPayment.Created();

            var result = await unitOfWork.Payments.CreateAsync(mappedPayment);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
        {
            var exist = await unitOfWork.Payments.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Payment not found!");

            exist.Deleted();

            await unitOfWork.Payments.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null)
        {
            var exist = unitOfWork.Payments.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("Payments not found");

            return exist;
        }

        public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            var exist = await unitOfWork.Payments.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Payment not found!");

            return exist;
        }

        public async Task<Payment> UpdateAsync(long id, PaymentForCreation paymentForCreation)
        {
            var exist = await unitOfWork.Payments.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Payment not found!");

            exist = mapper.Map(paymentForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Payments.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}