using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Service.Domain.UserHelper;
using User.Service.Domain.Repositories;
using User.Service.Infrastructure.Helpers;
using User.Service.Infrastructure.Repositories;

namespace User.Service.Infrastructure
{
	/// <summary>
	/// Методы расширешения уровня Infrastructure для работы с БД через EFCore
	/// </summary>
	public static class InfrastructureExtension
	{
		/// <summary>
		/// Метод расширения DI в части EF
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configs"><see cref="ConfigurationManager"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddEFInfrastructure(this IServiceCollection services, ConfigurationManager configs)
		{
			services.AddDbContext(configs);
			services.AddHelpers();
			services.AddRepositories();

			return services;
		}

		/// <summary>
		/// Добавление контекста БД
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddDbContext(this IServiceCollection services, ConfigurationManager configs)
		{
			var settings = configs.GetSection("DatabaseSettings").Get<DatabaseSettings>();
			if (settings is null)
			{
				throw new ApplicationException("Не задана конфигурация для подключения к БД");
			}

			services.AddDbContext<PublicContext>((options) =>
			{
				options.UseNpgsql(settings.ConnectionString);
			});

			return services;
		}

		/// <summary>
		/// Добавление реализации хелперов
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddHelpers(this IServiceCollection services)
		{
			services.AddScoped<IUserHelper, UserHelper>();

			return services;
		}

		/// <summary>
		/// Добавление реализации хелперов
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();

			return services;
		}
	}
}
