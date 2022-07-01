using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Repository;
using WebApi.Repository.Repositories;
using WebApi.Repository.UnitOfWorks;
using WebApi.Service.Mapping;
using WebApi.Service.Services;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql(Configuration.GetConnectionString("NpgsqlConnection"));

            });

            services.AddSwaggerGen();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IActionTypeService, ActionTypeService>();
            services.AddScoped<IActionTypeRepository, ActionTypeRepository>();

            services.AddScoped<IMaintenanceHistoryService, MaintenanceHistoryService>();
            services.AddScoped<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>();

            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();

            services.AddScoped<IPictureGroupService, PictureGroupService>();
            services.AddScoped<IPictureGroupRepository, PictureGroupRepository>();

            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();






            services.AddAutoMapper(typeof(MapProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
