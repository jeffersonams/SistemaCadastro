using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaDeTarefa.Data;
using SistemaDeTarefa.Repositorios;
using SistemaDeTarefa.Repositorios.Interfaces;

namespace SistemaDeTarefa
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

            //configurando o entity sqlserver 
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<SistemaTarefasDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            //configurando a injeção de dependencia 
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();  


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