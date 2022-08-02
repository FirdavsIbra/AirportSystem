using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Service.DTO_s.Payments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreateAsync(PaymentForCreation PaymentForCreation);
        Task<Payment> UpdateAsync(long id, PaymentForCreation PaymentForCreation);
        Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression);
        Task<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null);
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
    }
}