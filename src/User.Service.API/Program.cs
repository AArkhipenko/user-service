using AArkhipenko.Core;
using AArkhipenko.Logging;
using AArkhipenko.Swagger.Models;
using AArkhipenko.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using User.Service.Application;
using User.Service.Infrastructure;

using DomainConsts = User.Service.Domain.Consts;
using AArkhipenko.Keycloak.Security;

namespace User.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var versions = new[]
			{
				new OpenApiInfo
				{
					Version = "v10",
					Title = "User.Service API v1.0"
				}
			};

			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			builder.Services.AddCustomHealthCheck();
			builder.Services.AddVersioning();
			// AArkhipenko.Logging
			if (builder.Environment.IsDevelopment())
			{
				builder.Logging.AddConsoleLogging();
			}
			else
			{
				builder.Logging.AddFileLogging();
			}
			// AArkhipenko.Swagger
			builder.Services.AddCustomSwagger(versions, new[]
			{
				new SecurityModel(KeycloakSecurityScheme.DefaultKey, KeycloakSecurityScheme.Default)
			});

			// Методы расширения проектов
			builder.Services.AddMediatrExtension();
			builder.Services.AddEFInfrastructure(builder.Configuration);

			var app = builder.Build();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();
			// AArkhipenko.Logging
			app.UseLoggingMiddleware();
			// AArkhipenko.Swagger
			app.UseCustomSwagger(versions);

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}