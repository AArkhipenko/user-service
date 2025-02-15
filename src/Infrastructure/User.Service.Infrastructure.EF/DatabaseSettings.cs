namespace User.Service.Infrastructure.EF
{
	/// <summary>
	/// Насттройки подключения к БД
	/// </summary>
	internal class DatabaseSettings
	{
		/// <summary>
		/// Строка подключения к БД
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		/// Таймаут
		/// </summary>
		public int Timeout { get; set; }
	}
}
