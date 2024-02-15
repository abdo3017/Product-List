
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using Luftborn.BusinessLogic.Services;
using Luftborn.InfraStructure.Database;
using Luftborn.InfraStructure.DataServices;
using Luftborn.InfraStructure.Entity;
using Luftborn.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace VendingMachine
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var allowedOrigin=string.Empty;

            // Add services to the container.

            builder.Services.AddDbContextPool<ApplicationDbContext>(
                option => option.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IProductsManager, ProductsManager>();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader();
                    });
            });


            builder.Services.AddCors(op =>
            {
                op.AddPolicy(allowedOrigin, po =>

                {

                    po.AllowAnyMethod();

                    po.AllowAnyHeader();

                    po.AllowAnyOrigin();

                });

            });
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();

            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VendingMachine API", Version = "v1" });
            });

            //Add support to logging with SERILOG
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();



            var app = builder.Build();

            app.UseExceptionHandler(options => { });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VendingMachine v1"));
            }

            //uncomment the below line if you need to log process of API request
            //app.UseSerilogRequestLogging();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(op=>op.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
