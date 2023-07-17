using Eduzest.HRMS.DataAccess;
using Eduzest.HRMS.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Eduzest.HRMS.Repository.Interface;
using Eduzest.HRMS.Repository.Service;
using Eduzest.HRMS.WebApi.Services;
using Microsoft.Extensions.FileProviders;
using Eduzest.HRMS.WebApi.Extensions;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HrmsConnection") ?? throw new InvalidOperationException("Connection string have some issues.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddApplicationServices();
//serilog configuration
var _logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddSerilog(_logger);
//end of serilog
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads"))
                ),
    RequestPath = "/Uploads"
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
