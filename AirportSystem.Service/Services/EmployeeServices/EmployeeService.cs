﻿using System;
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
            var exist = await unitOfWork.Employees.GetAsync(a => a.Email == employeeForCreation.Email && a.PassportNumber == employeeForCreation.PassportNumber);

            if (exist is not null)
                throw new Exception("This employee already exists!");

            var mappedAirport = mapper.Map<Employee>(employeeForCreation);

            mappedAirport.Created();


            var result = await unitOfWork.Employees.CreateAsync(mappedAirport);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> CheckLoginAsync(string username, string password)
        {
            var oldEmp =  await unitOfWork.Employees.GetAsync(emp => emp.UserName == username && emp.Password == password);

            if (oldEmp is null)
                throw new Exception("This employee does not exist!");

            if (oldEmp.Password != password.GetHash())
            {
                throw new Exception("Wrong password!");
            }
            return true;
        }
        public async Task<Employee> ChangePasswordAsync(EmployeeForChangePassword forChangePassword)
        {
            var oldEmp = await unitOfWork.Employees.GetAsync(emp => emp.UserName == forChangePassword.Username);
            
            if(oldEmp is null)
                throw new Exception("This employee does not exist!");
            
            if(oldEmp.Password.GetHash() != forChangePassword.OldPassword.GetHash())
                throw new Exception("Password is wrong!");

            if(forChangePassword.NewPassword != forChangePassword.ConfirmPassword)
                throw new Exception("Passwords are not equal!");
            
            oldEmp.Password = forChangePassword.NewPassword.GetHash();
            unitOfWork.Employees.UpdateAsync(oldEmp);
            await unitOfWork.SaveChangesAsync();
            return oldEmp;
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

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
        {
            var exist = unitOfWork.Employees.GetAll(e => e.ItemState != ItemState.Deleted);

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