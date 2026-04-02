
using HRMS.Application.Interfaces;
using HRMS.Application.Services;
using HRMS.Infrastructure.Data;
using HRMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(Options =>
        Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("HRMS.Infrastructure")));


            builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();

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
        }
    }
}
