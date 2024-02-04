using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Service.Domain.Core.Logging
{
	/// <summary>
	/// Класс объекта раздела логирования
	/// </summary>
	public class LoggerWrapperScope: IDisposable
	{
		private ILogger _logger;
		private IDisposable _scope;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoggerWrapperScope"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="scopeName">название раздела логирования</param>
		/// <exception cref="ArgumentNullException">не зедан входной параметр</exception>
		/// <exception cref="Exception">не удалось создать объект раздела логирования</exception>
		public LoggerWrapperScope(ILogger logger, string scopeName)
		{
			if (scopeName is null)
			{
				throw new ArgumentNullException(nameof(logger));
			}

			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this._scope = this._logger.BeginScope(scopeName) ?? throw new Exception("Не создан объект логирования раздела");

			this._logger.LogInformation("Начало логирования раздела");
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			this._logger.LogInformation("Завершение логирования раздела");
			this._scope.Dispose();
		}
	}
}
