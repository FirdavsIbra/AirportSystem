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
                FirstName = "Ivawdan",
                LastName = "Ivanadadwov",
                UserName = "IVawda05",
                Address = "Main str. 1",
                Department = Department.Dispatcher,
                Email = "Ilaa@gmail.com",
                Gender = Gender.Male,
                Password = "iva009asada90",
                Phone = "54872136",
                Salary = 90000,
                PassportNumber = "AK13021410342",
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
                var result = await employeeService.CreateAsync(employeeForCreation);

                Console.WriteLine("Done");
            }
        }
    }
}