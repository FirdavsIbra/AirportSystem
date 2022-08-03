using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Airplanes;
using AirportSystem.Service.DTO_s.Employees;
using AirportSystem.Service.DTO_s.Passengers;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AirportSystem.Service.Services;
using AirportSystem.Service.Services.AirplaneServices;
using AirportSystem.Service.Services.EmployeeServices;
using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem
{
    internal class Program
    {


        static async Task Main(string[] args)
        {


            EmployeeForCreation employeeForCreation = new EmployeeForCreation()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                UserName = "IVa05",
                Address = "Main str. 1",
                Department = Department.Dispatcher,
                Email = "IVa@gmail.com",
                Gender = Gender.Male,
                Password = "iva00990",
                Phone = "5487236",
                Salary = 90000,
                PassportNumber = "RU1204140KL",
                DateOfBirth = DateTime.UtcNow
            };

            /*PassengerForCreation passengerForCreation = new PassengerForCreation()
            {
                Address = "Germany",
                FirstName = "Nouer",
                LastName = "Ter",
                AgeCategory = AgeCategory.Adult,
                CountryCode = "GER",
                Email = "nnAgele@gmail.com",
                Gender = Gender.Male,
                PassportNumber = "ML120411KMl",
                Phone = "0012456"
            };*/
            
            IMapper mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();
            
            using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            {
                EmployeeService employeeService = new EmployeeService(mapper, unitOfWork);
                var result = await employeeService.ChangePasswordAsync(new EmployeeForChangePassword()
                {
                    Username = "IVa05",
                    OldPassword = "iva00990",
                    NewPassword = "iva00991",
                    ConfirmPassword = "iva00991"
                });

                Console.WriteLine("Done");
            }
        }
    }
}