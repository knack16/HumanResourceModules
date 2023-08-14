using HumanResource.BLL.IServices;
using HumanResource.BLL.Services;
using HumanResource.DAL.Interfaces;
using HumanResource.DAL.Models;
using HumanResource.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// In Startup.cs ConfigureServices method
builder.Services.AddScoped<IGradeHistoryRepository, GradeHistoryRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Add other service references as needed

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeTravelDeskContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HRDatabaseString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
