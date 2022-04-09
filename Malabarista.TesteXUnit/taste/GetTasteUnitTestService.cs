using AutoMapper;
using Malabarista.Application.DTOs;
using Malabarista.Application.Mappings;
using Malabarista.Application.Services;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using Malabarista.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Malabarista.TesteXUnit.Taste
{
    public class GetTasteUnitTestService
    {
        private IMapper mapper;
        private IUnitOfWork repository;

        public static DbContextOptions<MalabaristaDbContext> dbContextOptions { get; }

        public static string connectionString =
        "server=bateaquihost.com.br;Database=everson2203211030_malabarista;user=everson2203211030_malabarista;password=Ev@malabarista123";

        static GetTasteUnitTestService( )
        {
            dbContextOptions = new DbContextOptionsBuilder<MalabaristaDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(new Version()))
            .Options;
        }

        //dências injetadas lá no controller


        public GetTasteUnitTestService( )
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());//MappingProfile tá lá em Mappings

            });
            mapper = config.CreateMapper(); //instância do automapper


            var context = new MalabaristaDbContext(dbContextOptions);

            repository = new UnitOfWork(context);

        }

        [Fact]
        public void GetTasteService_Return_OkResult()
        {           
            
            //Arrange
            var service = new TasteService(repository);
            
            //Act
            var data = service.GetTastes();

            //Assert
            //            Assert.IsType<IQueryable<GrainTasteDTO>>(data.GetType());
            Assert.IsNotType<List<string>>(data.GetType());
        }
    }
}

