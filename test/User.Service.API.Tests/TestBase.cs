using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace User.Service.API.Tests
{
	/// <summary>
	/// Базовый тестовый класс с различными методами для подготовки к тестированию
	/// </summary>
	internal class TestBase
	{
		/// <summary>
		/// Создание тестового http-клиента для проверки АПИ
		/// </summary>
		/// <returns><see cref="HttpClient"/></returns>
		public static HttpClient CreateClient(Action<IServiceCollection> configureServices) {
			var server = new WebApplicationFactory<Program>()
				.WithWebHostBuilder(builder =>
				{
					builder.ConfigureServices(configureServices);
				});
			var client = server.CreateClient();
			return client;
		}
	}
}
