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
using AirportSystem.Service.DTO_s.Orders;

namespace AirportSystem
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

            

            
            /*
            PassengerForCreation passengerForCreation = new PassengerForCreation()
            {
                Address = "Austria",
                FirstName = "Foster",
                LastName = "Barrett",
                UserName = "Jimmi",
                AgeCategory = AgeCategory.Adult,
                CountryCode = "GER",
                Email = "nnAgAele@gmail.com",
                Gender = Gender.Male,
                PassportNumber = "OO001241",
                Phone = "7845961",
                Password = "Mert1202",
                
            };
            */
            
            IMapper mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();
            
            using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            {
                EmployeeService passengerService = new EmployeeService(mapper,unitOfWork);
                var res = await passengerService.ChangePasswordAsync(new EmployeeForChangePassword()
                {
                    Username = "JasurChaqmoq",
                    OldPassword = "jasursdsa",
                    NewPassword = "mert",
                    ConfirmPassword = "mert"
                });
                Console.WriteLine("Done");
            }
        }
    }
}