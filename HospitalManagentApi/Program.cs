
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Infrastructure;
using Infrastructure.Services;
using Infrastructure.Interfaces;
using Microsoft.OpenApi.Models;
using Application.Services;
namespace HospitalManagentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            // Load configuration from appsettings.json

            var configuration = new ConfigurationBuilder()
               .SetBasePath(builder.Environment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            builder.Services.AddSwaggerGen(
                opt =>
                {
                    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter token",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer"
                    });
                    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                     Reference = new OpenApiReference
                        {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                    }
                },
            new string[]{}
        }
    });

                });

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
           
            builder.Services.AddScoped<IUserInfraService,UserInfraService> ();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IBaseApiClient, BaseApiClient>();
            builder.Services.AddScoped<IUserRoleInfra,UserRoleInfra>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IHttpcallServices, HttpcallServices>();

            builder.Services.AddHttpClient("TestClient",client=>
            {
                client.BaseAddress=new Uri("https://dummy.restapiexample.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            
            //move all this to other service/helper
            //move all this to other service/helper
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = configuration["JwtSettings:Issuer"],
              ValidAudience = configuration["JwtSettings:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
              ClockSkew = TimeSpan.FromMinutes(20)
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
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        
    }
}
