using AArkhipenko.Core;
using User.Service.API.Extensions;
using User.Service.API.Settings;
using User.Service.Application;
using User.Service.Infrastructure;
using DomainConsts = User.Service.Domain.Consts;

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
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddMediatrV10Extension();
			builder.Services.AddControllers();

			// Методы расширения из nuget-пакетов
			builder.Services.AddCustomHealthCheck();
			builder.Services.AddVersioning();

			var serviceProvider = builder.Services.BuildServiceProvider();
			builder.Logging.AddLoggingExtension(serviceProvider, builder.Environment.IsDevelopment());

			var app = builder.Build();

			app.Use(async (context, next) =>
			{
				// Добавление в заголовок запроса RequestId, если его нет
				if (!context.Request.Headers.TryGetValue(DomainConsts.RequestIdKey, out var requestId))
				{
					context.Request.Headers.Add(DomainConsts.RequestIdKey, Guid.NewGuid().ToString());
				}
				// Замена заголовка запроса, если это не гуид
				else if (!Guid.TryParse(requestId, out var requestId1))
				{
					context.Request.Headers.Remove(DomainConsts.RequestIdKey);
					context.Request.Headers.Add(DomainConsts.RequestIdKey, Guid.NewGuid().ToString());
				}

				await next.Invoke();
			});


			// Методы расширения из nuget-пакетов
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();

			app.UseSwaggerExtension(builder.Environment.IsDevelopment());
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}