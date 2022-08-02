using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Service.DTO_s.RoulTable;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Interfaces
{
    public interface IRoulTableService
    {
        Task<RouleTable> CreateAsync(RoulTableForCreation RouleTableForCreation);
        Task<RouleTable> UpdateAsync(long id, RoulTableForCreation RouleTableForCreation);
        Task<bool> DeleteAsync(Expression<Func<RouleTable, bool>> expression);
        Task<IEnumerable<RouleTable>> GetAllAsync(PaginationParams @params, Expression<Func<RouleTable, bool>> expression = null);
        Task<RouleTable> GetAsync(Expression<Func<RouleTable, bool>> expression);
    }
}