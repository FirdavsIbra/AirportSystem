using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Commons;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Service.Interfaces.IDeleteForAdmins;
using AirportSystem.Service.Mappers;
using AutoMapper;

namespace AirportSystem.Service.Services.DeleteForAdmins
{
    public class DeleteForAdmin<T> : IDeleteForAdmin<T> where T : Auditable
    {
        private readonly IGenericRepository<T> _repository;

        public DeleteForAdmin()
        {
            AirportSystemDbContext context = new AirportSystemDbContext();
            _repository = new GenericRepository<T>(context);
        }
        
        public async Task<bool> DeleteManyAsync(Expression<Func<T, bool>> expression = null)
        {
            while (true)
            {
                var result = await _repository.DeleteAsync(expression);
                if (result is false)
                {
                    break;
                }
                

              //  await _repository.SaveChangesAsync();
            }
            

            return false;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _repository.DeleteAsync(expression);

          //  await _repository.SaveChangesAsync();

            return result;
        }
    }
        
        
}
    
