using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Service.Domain.Repositories;
using User.Service.Infrastructure.Repositories;
using AArkhipenko.Keycloak;

namespace User.Service.Infrastructure
{
	/// <summary>
	/// Методы расширешения уровня Infrastructure
	/// </summary>
	public static class InfrastructureExtension
	{
		/// <summary>
		/// Добавление всех расширений с уровня Infrastructure
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configuration"><see cref="IConfiguration"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
			=> services
				.AddDbContext(configuration)
				.AddRepositories()
				.AddKeycloakAuth(configuration);

		/// <summary>
		/// Добавление контекста БД
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configuration"><see cref="IConfiguration"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddDbContext(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString(Consts.ConnectionString) ??
				throw new ApplicationException($"Не задана строка подключения к БД с пользователями. " +
					$"Раздел ConnectionStrings:{Consts.ConnectionString}.");

			services.AddDbContext<UserDbContext>((options) =>
			{
				options.UseNpgsql(connectionString);
			});

			return services;
		}

		/// <summary>
		/// Добавление репозиториев
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddRepositories(this IServiceCollection services)
			=> services
			.AddScoped<IUserRepository, UserRepository>();
	}
}
