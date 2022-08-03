using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Airplanes;

namespace AirportSystem.Service.Interfaces.IDeleteForAdmins
{
    public interface IDeleteForAdmin<T> where T : Auditable
    {
        Task<bool> DeleteManyAsync(Expression<Func<T, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}