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
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;

namespace AirportSystem
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

            /*
            PassengerForCreation passengerForCreation = new PassengerForCreation()
            {
                Address = "Argentina",
                FirstName = "Marina",
                LastName = "Johnson",
                AgeCategory = AgeCategory.Adult,
                CountryCode = "ARG",
                Email = "Marianai@gmail",
                Gender = Gender.Female,
                PassportNumber = "OK129349",
                Phone = "+741852963"
            };

            EmployeeForCreation employeeForCreation = new EmployeeForCreation()
            {
                Email = "Malika@gmial.com",
                Address = "uzb",
                DateOfBirth = DateTime.UtcNow,
                FirstName = "Malika",
                Department = Department.Cashier,
                Gender = Gender.Female,
                LastName = "Ahmedova",
                PassportNumber = "AFP91234KA",
                Password = "Malikk00",
                Phone = "+9983312345",
                Salary = 230000,
            };
            */
            

            IMapper mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
            PassengerService passengerService = new PassengerService(mapper, unitOfWork);


            //PaginationParams @params = new PaginationParams(1,1);
            //var ress = passengerService.GetAllAsync(@params);



        }
    }
}