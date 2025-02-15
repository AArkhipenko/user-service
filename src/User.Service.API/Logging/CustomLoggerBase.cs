using MediatR.NotificationPublishers;
using Newtonsoft.Json;
using System;
using User.Service.Domain.Core;
using User.Service.Domain.Core.Logging;

namespace User.Service.API.Logging
{
	/// <summary>
	/// База класс кастомного логера
	/// </summary>
	internal abstract class CustomLoggerBase : ILogger, IDisposable
	{
		private ScopeModel? _scopeModel = null;
		private readonly Formatting _jsonFormatting;
		private readonly IHttpContextAccessor _contextAccessor;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomLoggerBase"/> class.
		/// </summary>
		/// <param name="jsonFormatting"><see cref="Formatting"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public CustomLoggerBase(
			Formatting jsonFormatting,
			IHttpContextAccessor contextAccessor)
		{
			this._jsonFormatting = jsonFormatting;
			this._contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
		}

		/// <inheritdoc/>
		public bool IsEnabled(LogLevel logLevel) => true;

		/// <inheritdoc/>
		public IDisposable BeginScope<TState>(TState scopeModel)
		{
			if (scopeModel is not null && scopeModel is ScopeModel)
			{
				this._scopeModel = scopeModel as ScopeModel;
			}
			return this;
		}

		/// <inheritdoc/>
		public abstract void Log<TState>(
			LogLevel logLevel,
			EventId eventId,
			TState state,
			Exception? exception,
			Func<TState, Exception?, string> formatter);

		/// <inheritdoc/>
		public void Dispose() { }

		/// <summary>
		/// Формирование отформатированного сообщения для лога
		/// </summary>
		/// <param name="logLevel">уровень логирования</param>
		/// <param name="message">сообщение для лога</param>
		/// <param name="exception">выброшенное исключение</param>
		/// <returns>строка json</returns>
		protected string FormatMessage(LogLevel logLevel, string message, Exception? exception)
		{
			Guid? requestId = null;
			var context = this._contextAccessor.HttpContext;
			if (context is not null
				&& context.Request.Headers.TryGetValue(Consts.RequestIdKey, out var requestIdStr))
			{
				if(Guid.TryParse(requestIdStr, out var parsedRequestId))
				{
					requestId = parsedRequestId;
				}
			}
			var logEntry = new LogEntry
			{
				Timestamp = DateTime.UtcNow,
				LogLevel = logLevel.ToString(),
				RequestId = requestId ?? Guid.Empty,
				Scope = this._scopeModel is null ? "unknown" : $"{this._scopeModel.ClassName}.{this._scopeModel.MethodName}",
				Message = message,
				Exception = exception?.ToString()
			};

			return JsonConvert.SerializeObject(logEntry, this._jsonFormatting);
		}

		private class LogEntry
		{
			/// <summary>
			/// Временная метка
			/// </summary>
			public DateTime Timestamp { get; set; }

			/// <summary>
			/// ID запроса (нужен для отслеживания последовательности вызовов)
			/// </summary>
			public Guid RequestId { get; set; }

			/// <summary>
			/// Уровень логирования
			/// </summary>
			public string LogLevel { get; set; } = string.Empty;

			/// <summary>
			/// Раздел логирования
			/// </summary>
			public string Scope { get; set; } = string.Empty;

			/// <summary>
			/// Сообщение для лога
			/// </summary>
			public string Message { get; set; } = string.Empty;

			/// <summary>
			/// Сообщение исключения
			/// </summary>
			public string? Exception { get; set; }
		}
	}
}
