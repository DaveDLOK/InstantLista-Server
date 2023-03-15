

using InstantLista_ClassLibrary.Helpers;
using InsantLista_Services.Interfaces;
using InsantLista_Services.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using InstantLista_DataAccess;
using InstantLista_DataAccess.Interfaces;
using InstantLista_DataAccess.Repositories;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var AppSettingsConfiguration = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppSettings>(AppSettingsConfiguration);
        var appSettings = AppSettingsConfiguration.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
        var dbConnectionString = builder.Configuration.GetConnectionString("InstantListaDB");

        // Add mysql connection
        builder.Services.AddDbContext<InstantListaDBContext>(options => options.UseMySql(dbConnectionString,serverVersion));

        builder.Services.AddAuthentication(a =>
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(a =>
        {
            a.RequireHttpsMetadata = false; //only when development
            a.SaveToken = true;
            a.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        builder.Services.AddControllers();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<INewsService, NewsService>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
        builder.Services.AddScoped<INewsRepository, NewsRepository>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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