using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace User.Service.API.Extensions
{
	/// <summary>
	/// Методы расширения для использования Swagger
	/// </summary>
	public static class SwaggerExtention
	{
		/// <summary>
		/// Добавления настроек для работы с Swagger
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v10", new OpenApiInfo
				{
					Version = "v10",
					Title = $"User.Service API v1.0",
				});
			});

			return services;
		}

		/// <summary>
		/// Включение использования Swagger
		/// </summary>
		/// <param name="app"><see cref="IApplicationBuilder"/></param>
		/// <param name="isDevelopment">признак режима разработки</param>
		/// <returns><see cref="IApplicationBuilder"/></returns>
		public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app, bool isDevelopment)
		{
			if (isDevelopment)
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("v10/swagger.json", $"User.Service API v1.0");
					c.SwaggerEndpoint("v11/swagger.json", $"User.Service API v1.1");
				});
			}

			return app;
		}
	}
}
