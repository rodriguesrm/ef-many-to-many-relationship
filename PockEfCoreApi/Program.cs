using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PockEfCoreApi.Infra.Data;

namespace PockEfCoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<PockDbContext>(delegate (DbContextOptionsBuilder opt)
            {

                var connectionString = builder.Configuration.GetConnectionString("DbServer");

                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                opt.UseLazyLoadingProxies();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
