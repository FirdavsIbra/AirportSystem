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

            PassengerForCreation passengerForCreation = new PassengerForCreation()
            {
                Address = "Toshkent vil",
                FirstName = "Toxir",
                LastName = "Khanov",
                AgeCategory = AgeCategory.Adult,
                CountryCode = "Uz",
                Email = "dlkbmfdlb@gmail.com",
                Gender = Gender.Male,
                PassportNumber = "24crcgveg",
                Phone = "123456789"
            };

            EmployeeForCreation employeeForCreation = new EmployeeForCreation()
            {
                Email = "bfdjkdvdasdff@gmial.com",
                Address = "Toshkent",
                DateOfBirth = DateTime.UtcNow,
                FirstName = "Toxirali",
                Department = Department.FoodServiceWorker,
                Gender = Gender.Male,
                LastName = "Botiraliev",
                PassportNumber = "AC65432435f",
                Password = "cvfC2131@d",
                Phone = "12345444",
                Salary = 124232,

            };
            
            IMapper Mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();
            
            using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            {
                EmployeeService employeeService = new EmployeeService(Mapper, unitOfWork);

                var bb = await employeeService.DeleteAsync(Expressi => Expressi.Id == 2);

                Console.WriteLine(bb);
            }
        }
    }
}