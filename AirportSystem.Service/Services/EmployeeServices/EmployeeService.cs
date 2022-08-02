using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Employees;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Employees;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;

namespace AirportSystem.Service.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
        public async Task<Employee> CreateAsync(EmployeeForCreation employeeForCreation)
        {
            var exist = await unitOfWork.Employees.GetAsync(a => a.Email == employeeForCreation.Email);

            if (exist is not null)
                throw new Exception("This employee already exists!");

            var mappedAirport = mapper.Map<Employee>(employeeForCreation);

            mappedAirport.Created();

            var result = await unitOfWork.Employees.CreateAsync(mappedAirport);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<Employee> UpdateAsync(long id, EmployeeForCreation employeeForCreation)
        {
            var exist = await unitOfWork.Employees.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This employee not found!");

            exist = mapper.Map(employeeForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Employees.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression)
        {
            var exist = await unitOfWork.Employees.GetAsync(expression);

            if (exist is null)
                throw new Exception("This employee not found!");

            exist.Deleted();

            await unitOfWork.Employees.DeleteAsync(expression);

            return true;
        }

        public Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
        {
            var exist = unitOfWork.Employees.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);

            if (exist is null)
                throw new Exception("employee not found");

            return Task.FromResult<IEnumerable<Employee>>(exist);
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var exist = await unitOfWork.Employees.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This employee   not found!");

            return exist;
        }
    }
}