using Application.Interface;
using Application.Repository;
using Application.Service;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Add services to the container.
builder.Services.AddScoped<IStage, StageService>();
builder.Services.AddScoped<IStageRepository, StageRepository>();

builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IProcess, ProcessService>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();


builder.Services.AddScoped<IProcessStage, ProcessStageService>();
builder.Services.AddScoped<IProcessStageRepository, ProcessStageRepository>();


builder.Services.AddScoped<IProcessRequst, ProcessRequstService>();
builder.Services.AddScoped<IProcessRequstRepository, ProcessRequstRepository>();



builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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