

using AutoMapper;
using Malabarista.Application.Interfaces;
using Malabarista.Application.Mappings;
using Malabarista.Application.Services;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using Malabarista.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Malabarista.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Mapaemento das DTOs

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile: new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            //Addd Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<IFilterGrainService, FilterGrainService>();
            services.AddScoped<IGrainCountService, GrainCountService>();



            var mySqlStringConection = Configuration["ConnectionStrings:DefaultString"];
            services.AddDbContext<MalabaristaDbContext>(
                                  option => option.UseMySql(mySqlStringConection
                                  ,new MySqlServerVersion(new Version())
                                  //,options => options.EnableRetryOnFailure()
                                  )
                                  );
            
            //Importantíssimo
            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Malabarista.API", Version = "v1" });
            });


            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Malabarista.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
        }
    }
}
