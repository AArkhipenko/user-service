using User.Service.API.Logging;

namespace User.Service.API.Extensions
{
	/// <summary>
	/// Методы расширешения для настройки логирования в приложении
	/// </summary>
	public static class LoggingExtention
	{
		/// <summary>
		/// Добавления настроект логирования
		/// </summary>
		/// <param name="builder"><see cref="ILoggingBuilder"/></param>
		/// <param name="isDevelopment">признак режима разработки</param>
		/// <returns><see cref="ILoggingBuilder"/></returns>
		public static ILoggingBuilder AddLoggingExtension(this ILoggingBuilder builder, bool isDevelopment)
		{
			// Удаление всех провайдеров
			builder.ClearProviders();

			if (!isDevelopment)
			{
				// Добавление провайдера логирования в консоль
				builder.AddConsole();
			}
			else
			{
				// Добавление провайдера логирования в файл
				builder.AddProvider(new FileLoggerProvider("./output"));
			}

			return builder;
		}
	}
}
