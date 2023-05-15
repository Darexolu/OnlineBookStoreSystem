using OnlineBookStoreSystem.Data;
using Microsoft.EntityFrameworkCore;
namespace OnlineBookStoreSystem
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
            builder.Services.AddDbContext<OnlineDbContext>(options => options.UseSqlite
               (builder.Configuration.GetConnectionString("OnlineBookStoreSystemConnection")));
            builder.Services.AddCors(options => options.AddPolicy("all", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));//EnablingCors

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("all");

            app.MapControllers();

            app.Run();
        }
    }
}