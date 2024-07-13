using TheFinalProject.core.ICommon;
using TheFinalProject.core.IRepositories;
using TheFinalProject.core.IServices;
using TheFinalProject.infra.Common;
using TheFinalProject.infra.Repositories;
using TheFinalProject.infra.Services;

namespace TheFinalProject.API
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

            builder.Services.AddScoped<IDbContext, DbContext>();

            //REpository 
            builder.Services.AddScoped<IHallRepository,HallRepository>();

            //Services
            builder.Services.AddScoped<IHallService,HallService>();


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
