using System.Net;
using Controller = User.Service.API.Controllers.V10.ExampleController;

namespace User.Service.API.Tests.Controllers.V10.ExampleController
{
	/// <summary>
	/// Тесты на метод <see cref="Controller.GetAsync(CancellationToken)"/>
	/// </summary>
    public class GetAsyncTests
    {
		/// <summary>
		/// Корректное выполнение АПИ
		/// </summary>
		/// <returns>OK</returns>
		[Fact]
		public async Task It_returns_OK()
		{
			// Настройки приложения
			var testClient = TestBase.CreateClient(services => { });

			// Выполнение запроса
			var response = await testClient.GetAsync("/examples/v10");

			// Тесты результата
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var content = await response.ReadAsJsonAsync<IEnumerable<int>>();

			Assert.NotNull(content);
			Assert.NotEmpty(content);
		}
    }
}
