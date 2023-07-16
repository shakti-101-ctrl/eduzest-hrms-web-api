using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HrmsConnection") ?? throw new InvalidOperationException("Connection string have some issues.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();

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
