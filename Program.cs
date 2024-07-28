
using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Repositories;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem
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

            // Connecting to the database
            builder.Services.AddDbContext<TaskSystemDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            // Setting dependencies injection in project
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository> ();

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
