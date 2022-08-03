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
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Service.Interfaces.IDeleteForAdmins;
using AirportSystem.Service.Services.DeleteForAdmins;

namespace AirportSystem
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

            



            

            IMapper Mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();
            
            using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            {
                PassengerService passengerService = new PassengerService(Mapper, unitOfWork);
            }
            IMapper Mapper1 = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext1 = new AirportSystemDbContext();

            using (IUnitOfWork unitOfWork1 = new UnitOfWork(dbContext1))
            {
                EmployeeService employeeService = new EmployeeService(Mapper1, unitOfWork1);

            }
            
            IDeleteForAdmin<Passenger> deleteForAdmin = new DeleteForAdmin<Passenger>();
            await deleteForAdmin.DeleteManyAsync(e => e.Id < 5);

            Console.WriteLine("Done");
        }
    }
}