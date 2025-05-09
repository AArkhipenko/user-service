using AArkhipenko.Core;
using AArkhipenko.Logging;
using AArkhipenko.Swagger.Models;
using AArkhipenko.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using User.Service.Application;
using User.Service.Infrastructure;

using AArkhipenko.Keycloak.Security;

namespace User.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		private readonly static OpenApiInfo[] _versions = new[]
		{
			new OpenApiInfo
			{
				Version = "v10",
				Title = "User.Service API v1.0"
			}
		};

		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication
				.CreateBuilder(args);

#if DEBUG
			builder.Configuration.AddYamlFile("DebugConfig.yml", false);
#endif

			builder.Services.AddControllers();
			builder.Services.AddHttpContextAccessor();
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
			builder.Services.AddCustomSwagger(_versions, new[]
			{
				new SecurityModel(KeycloakSecurityScheme.DefaultKey, KeycloakSecurityScheme.Default)
			});

			// Методы расширения проектов
			builder.Services.AddMediatrExtension();
			builder.Services.AddInfrastructure(builder.Configuration);

			var app = builder.Build();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();
			// AArkhipenko.Logging
			app.UseLoggingMiddleware();
			// AArkhipenko.Swagger
			app.UseCustomSwagger(_versions);

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}