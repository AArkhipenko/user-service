namespace User.Service.API.Logging
{
	/// <summary>
	/// Провайдер для <see cref="FileLogger"/>
	/// </summary>
	internal class FileLoggerProvider : ILoggerProvider
	{
		private readonly string _filePath;
		private readonly IHttpContextAccessor _contextAccessor;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileLoggerProvider"/> class.
		/// </summary>
		/// <param name="filePath">путь к файлу для записи лога</param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public FileLoggerProvider(
			string filePath,
			IHttpContextAccessor contextAccessor)
		{
			this._filePath = filePath;
			this._contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
		}

		/// <inheritdoc/>
		public ILogger CreateLogger(string categoryName)
		{
			return new FileLogger(this._filePath, this._contextAccessor);
		}

		/// <inheritdoc/>
		public void Dispose() { }
	}
}
