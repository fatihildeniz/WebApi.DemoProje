using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Demo2.Filters;

using WebApi.Demo2.Filters.Security;
using WebApi.Repository;
using WebApi.Repository.Repositories;
using WebApi.Repository.UnitOfWorks;
using WebApi.Service;
using WebApi.Service.Filters;
using WebApi.Service.Filters.ActionTypeValidators;
using WebApi.Service.Filters.MaintenanceHistoryValidators;
using WebApi.Service.Filters.MaintenanceValidators;
using WebApi.Service.Filters.PictureGroupValidators;
using WebApi.Service.Filters.StatusValidators;
using WebApi.Service.Filters.UserValidators;
using WebApi.Service.Filters.VehicleTypeValidators;
using WebApi.Service.Filters.VehicleValidators;
using WebApi.Service.Mapping;
using WebApi.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x=>
x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("NpgsqlConnection"));

});

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddTransient<IUserAuthenticationRepository, UserAuthenticationRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IActionTypeService, ActionTypeService>();
builder.Services.AddTransient<IActionTypeRepository, ActionTypeRepository>();

builder.Services.AddTransient<IMaintenanceHistoryService, MaintenanceHistoryService>();
builder.Services.AddTransient<IMaintenanceHistoryRepository, MaintenanceHistoryRepository>();

builder.Services.AddTransient<IMaintenanceService, MaintenanceService>();
builder.Services.AddTransient<IMaintenanceRepository, MaintenanceRepository>();

builder.Services.AddTransient<IPictureGroupService, PictureGroupService>();
builder.Services.AddTransient<IPictureGroupRepository, PictureGroupRepository>();

builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();

builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();

builder.Services.AddTransient<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();

builder.Services.AddTransient<UserSaveValidatorFilter>();
builder.Services.AddTransient<UserUpdateValidatorFilter>();
builder.Services.AddTransient<ActionTypeSaveValidatorFilter>();
builder.Services.AddTransient<ActionTypeUpdateValidatorFilter>();
builder.Services.AddTransient<MaintenanceHistorySaveValidatorFilter>();
builder.Services.AddTransient<MaintenanceHistoryUpdateValidatorFilter>();
builder.Services.AddTransient<MaintenanceSaveValidatorFilter>();
builder.Services.AddTransient<MaintenanceUpdateValidatorFilter>();
builder.Services.AddTransient<PictureGroupSaveValidatorFilter>();
builder.Services.AddTransient<PictureGroupUpdateValidatorFilter>();
builder.Services.AddTransient<StatusSaveValidatorFilter>();
builder.Services.AddTransient<StatusUpdateValidatorFilter>();
builder.Services.AddTransient<VehicleSaveValidatorFilter>();
builder.Services.AddTransient<VehicleUpdateValidatorFilter>();
builder.Services.AddTransient<VehicleTypeSaveValidatorFilter>();
builder.Services.AddTransient<VehicleTypeUpdateValidatorFilter>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOption, BasicAuthenticationHandler>("Basic", null);
//builder.Services.AddTransient<IAuthenticationHandler, BasicAuthenticationHandler>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
