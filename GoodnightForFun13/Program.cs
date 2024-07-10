
using GoodnightForFun13.Data;
using GoodnightForFun13.Repository;
using Microsoft.EntityFrameworkCore;

namespace GoodnightForFun13
{
    public class Program
    {
        ///TODO: ������� web api TODO ���� - ������� � �����, �����, ����� � ��.
        public static void Main(string[] args)
        {
            ///TODO: ��� ������� ����������� �� ������������ ��������� �������, ����� ����� � ������� �� ����������� � ���������.
            ///TODO: ������� ��������� ������.



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(o =>
            {
                o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //builder.Services.AddScoped<UOWRep, AppDbContext>();

            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped<UOWRep>();


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
