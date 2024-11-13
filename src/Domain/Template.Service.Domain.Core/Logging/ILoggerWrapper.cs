﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service.Domain.Core.Logging
{
	/// <summary>
	/// Интерфейс обертки для логирования
	/// </summary>
	public interface ILoggerWrapper
	{
		/// <summary>
		/// Объекл логирования
		/// </summary>
		public ILogger Logger { get; }

		/// <summary>
		/// Начало логирования раздела
		/// </summary>
		/// <param name="myCallerName">название метода, из которого выпонен вызов</param>
		/// <param name="callerClassName">название класса, из которого выпонен вызов</param>
		/// <returns><see cref="LoggerWrapperScope"/></returns>
		public LoggerWrapperScope BeginLoggingScope(string? myCallerName = null, string? callerClassName = null);
	}
}
