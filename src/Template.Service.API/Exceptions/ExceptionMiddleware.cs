﻿using Microsoft.AspNetCore.Http;
using System.Net;
using Template.Service.Domain.Core.Exceptions;

namespace Template.Service.API.Exceptions
{
	/// <summary>
	/// Прослойка обработки исключений
	/// </summary>
	internal class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
		/// </summary>
		/// <param name="next"><see cref="RequestDelegate"/></param>
		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// Выполнение запроса
		/// </summary>
		/// <param name="httpContext"><see cref="HttpContext"/></param>
		/// <returns><see cref="Task"/></returns>
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				await ExceptioHandleAsync(httpContext, ex);
			}
		}

		/// <summary>
		/// Обработка ситуации, когда возникает исключение
		/// </summary>
		/// <param name="httpContext">контекст http запроса</param>
		/// <param name="exception">исключение, возникшее в результате выполнения запроса</param>
		/// <returns><see cref="Task"/></returns>
		private async Task ExceptioHandleAsync(HttpContext httpContext, Exception exception)
		{
			_ = exception switch
			{
				ArgumentException => httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest,
				BadRequestException => httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest,
				NotFoundException => httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound,
				_ => httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError,
			};

			var responseException = new ResponseExceptionModel(exception);
			await httpContext.Response.WriteAsJsonAsync<ResponseExceptionModel>(responseException);
		}
	}
}
