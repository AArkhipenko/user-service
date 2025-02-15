namespace User.Service.API.Logging
{
	/// <summary>
	/// Провайдер для <see cref="JsonConsoleLogger"/>
	/// </summary>
	internal class JsonConsoleLoggerProvider : ILoggerProvider
	{
		private readonly IHttpContextAccessor _contextAccessor;

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonConsoleLoggerProvider"/> class.
		/// </summary>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public JsonConsoleLoggerProvider(IHttpContextAccessor contextAccessor)
			: base()
		{
			this._contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
		}

		/// <inheritdoc/>
		public ILogger CreateLogger(string categoryName)
		{
			return new JsonConsoleLogger(this._contextAccessor);
		}

		/// <inheritdoc/>
		public void Dispose() { }
	}
}
