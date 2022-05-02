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

namespace Malabarista.TesteXUnit
{
    public class GrainCountUnitTestService
    {

        private IMapper mapper;
        private IUnitOfWork repository;

       
        public static DbContextOptions<MalabaristaDbContext> dbContextOptions { get; }

        public static string connectionString =
        "Adicione sua conection string aqui";

        static GrainCountUnitTestService( )
        {
            
            dbContextOptions = new DbContextOptionsBuilder<MalabaristaDbContext>()
            .UseMySql(MyConectionString.connectionString, new MySqlServerVersion(new Version()))
            .Options;
        }
        //dências injetadas lá no controller


        public GrainCountUnitTestService( )
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
        public void GrainCount_Return_Int()
        {           
            
            //Arrange
//            var testDTO = new TasteChooseDTO(new GrainNotes("", "", ""), "Chocolate");
            var service = new GrainCountService(repository);
            
            //Act
            var data = service.GrainCount();
            
            //Assert

            Assert.IsType<Int32>(data); 
        }
    }
}

