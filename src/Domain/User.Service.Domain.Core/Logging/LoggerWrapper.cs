using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace User.Service.Domain.Core.Logging
{
	/// <summary>
	/// Реализация <see cref="ILoggerWrapper" />
	/// </summary>
    public class LoggerWrapper: ILoggerWrapper
	{
		private readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoggerWrapper"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public LoggerWrapper(
			ILogger logger)
		{
			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc/>
		public ILogger Logger { get => this._logger; }

		/// <inheritdoc/>
		public LoggerWrapperScope BeginLoggingScope([CallerMemberName] string? callerMethodName = null, string? callerClassName = null)
		{
			var scopeModel = new ScopeModel
			{
				ClassName = callerClassName ?? this.GetType().Name,
				MethodName = callerMethodName ?? "unknown",
			};

			return new LoggerWrapperScope(this._logger, scopeModel);
		}
	}
}
