namespace User.Service.API.Logging
{
	/// <summary>
	/// Логер для записи в файл
	/// </summary>
	public class FileLogger : ILogger, IDisposable
	{
		private readonly string _filePath;
		static object _lock = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="FileLogger"/> class.
		/// </summary>
		/// <param name="filePath">путь к файлу для записи лога</param>
		public FileLogger(string filePath) => this._filePath = filePath;

		/// <inheritdoc/>
		public bool IsEnabled(LogLevel logLevel) => true;

		/// <inheritdoc/>
		public IDisposable BeginScope<TState>(TState state) => this;

		/// <inheritdoc/>
		public void Log<TState>(
			LogLevel logLevel,
			EventId eventId,
			TState state,
			Exception? exception,
			Func<TState, Exception?, string> formatter)
		{
			lock (_lock)
			{
				File.AppendAllText(this._filePath, formatter(state, exception) + Environment.NewLine);
			}
		}

		/// <inheritdoc/>
		public void Dispose() { }
	}
}
