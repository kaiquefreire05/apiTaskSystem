
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using System.Reflection;
using System.Text;
using TaskSystem.Data;
using TaskSystem.Integration;
using TaskSystem.Integration.Interfaces;
using TaskSystem.Integration.Refit;
using TaskSystem.Repositories;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            string secretKey = "f64feb14-60a0-43d4-8592-58d97f16d4d8";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Configure swagger
            builder.Services.AddSwaggerGen(c =>
            {
                // Define a documentação do Swagger para a versão v1 da API
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Task System - API", // Título da documentação da API
                    Version = "v1" // Versão da API
                });

                // Configuração do esquema de segurança para autenticação JWT
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication", // Nome do esquema de segurança
                    Description = "Enter with JWT token", // Descrição do esquema de segurança
                    In = ParameterLocation.Header, // Localização do token (cabeçalho da requisição)
                    Type = SecuritySchemeType.Http, // Tipo de esquema de segurança (HTTP)
                    Scheme = "bearer", // Esquema de autenticação (Bearer)
                    BearerFormat = "JWT", // Formato do token (JWT)
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme, // Identificador do esquema de autenticação JWT
                        Type = ReferenceType.SecurityScheme // Tipo de referência (esquema de segurança)
                    }
                };

                // Adiciona a definição de segurança ao Swagger
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);

                // Define os requisitos de segurança para a API
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                {securitySchema, new string[] {} } // Aplica o esquema de segurança sem escopos específicos
                });
            });



            // Connecting to the database
            builder.Services.AddDbContext<TaskSystemDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            // Setting dependencies injection in project
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository> ();
            builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

            // Configure API ViaCep
            builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c => 
            { c.BaseAddress = new Uri("https://viacep.com.br");}
            );

            // Configure authentication
            builder.Services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, // Expire time
                    ValidateIssuerSigningKey = true, 
                    ValidIssuer = "sua_empresa",
                    ValidAudience = "sua_aplicacao",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Adding authentication
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
