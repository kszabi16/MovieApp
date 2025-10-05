using Microsoft.EntityFrameworkCore;
using MovieApp.DataContext.Context;
using MovieApp.Services;
namespace MovieApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<MovieAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieAppContext")));

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutomapperProfile>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
