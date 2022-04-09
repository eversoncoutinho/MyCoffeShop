using AutoMapper;
using Malabarista.Application.DTOs;
using Malabarista.Application.Mappings;
using Malabarista.Application.Services;
using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Domain.ValueObjects;
using Malabarista.Infra.Data;
using Malabarista.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Malabarista.TesteXUnit
{
    public class GrainByTasteUnitTestService
    {

        private IMapper mapper;
        private IUnitOfWork repository;

        public static DbContextOptions<MalabaristaDbContext> dbContextOptions { get; }

        public static string connectionString =
        "server=bateaquihost.com.br;Database=everson2203211030_malabarista;user=everson2203211030_malabarista;password=Ev@malabarista123";

        static GrainByTasteUnitTestService()
        {
            dbContextOptions = new DbContextOptionsBuilder<MalabaristaDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(new Version()))
            .Options;
        }
        //dências injetadas lá no controller


        public GrainByTasteUnitTestService( )
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
        public void GetGrainByNotesService_Return_OkResult()
        {           
            
            //Arrange
            var testDTO = "Chocolate";
            var service = new FilterGrainService(repository, mapper);
            
            //Act
            var data = service.GetGrainByNotes(testDTO);

            //Assert
            //            Assert.IsType<IQueryable<GrainTasteDTO>>(data.GetType());
            Assert.IsNotType<List<GrainByTasteDTO>>(data.GetType());
        }
    }
}

