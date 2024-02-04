using User.Service.API.Extensions;
using User.Service.Application.V10;

namespace User.Service.Api
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

			// Добавление поддержки Mediatr для проекта User.Service.Application.V10
			builder.Services.AddMediatrV10Extension();
			// Add services to the container
			builder.Services.AddControllers();
			// Добавление версионирования
			builder.Services.AddVersionExtension();
			// Добавление работы со Swagger
			builder.Services.AddSwaggerExtension();
			builder.Logging.AddLoggingExtension(builder.Environment.IsDevelopment());

			var app = builder.Build();

			// Использование Swagger
			app.UseSwaggerExtension(app.Environment.IsDevelopment());
			// Configure the HTTP request pipeline
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}