using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace User.Service.API.Tests
{
	/// <summary>
	/// Базовый тестовый класс
	/// </summary>
	public class TestBase
	{
		private ITestOutputHelper _testOutputHelper;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestBase"/> class.
		/// </summary>
		/// <param name="testOutputHelper"><see cref="ITestOutputHelper"/></param>
		public TestBase(ITestOutputHelper testOutputHelper)
		{
			this._testOutputHelper = testOutputHelper;
		}

		/// <summary>
		/// Получение логера для тестов
		/// </summary>
		public ITestOutputHelper TestOutputHelper { get { return _testOutputHelper; } }

		/// <summary>
		/// Создание тестового http-клиента для проверки АПИ
		/// </summary>
		/// <param name="configureServices">метод настройки DI</param>
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
