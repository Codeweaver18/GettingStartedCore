using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GettingStartedCore.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using GettingStartedCore.DataAccess.Repositories;
using GettingStartedCore.DataAccess.Abstract;
using GettingStartedCore.DataAccess.Entities;
using GettingStartedCore.DTO;
using GettingStartedCore.core.Business;
using GettingStartedCore.core.Abstract;

namespace GettingStartedCore
{
    public class Startup
    {
        private  readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.addidentityserver();
                    
            services.AddDbContext<GettingStartedContext>(options=>options.UseSqlServer(_config.GetValue<string>("ConnectionStrings:DefaultConnection")));
            services.AddScoped<IEmployeeRespository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, GettingStartedContext context)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            
            loggerFactory.AddDebug(LogLevel.Information);
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            context.EnsureSeedDataForContext();
            AutoMapper.Mapper.Initialize(cfg => {

                cfg.CreateMap<Employee, EmployeeDTO>();

            });
        }
    }
}
