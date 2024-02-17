using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using User.Service.Application.V10.Example.Queries;
using User.Service.Domain.Core.Exceptions;
using User.Service.Domain.Core.Logging;

namespace User.Service.Application.V10.Example.Hadlers
{
	/// <summary>
	/// Выполнение <see cref="GetExceptionQuery"/>
	/// </summary>
	internal class GetExceptionQueryHandler : LoggerWrapper, IRequestHandler<GetExceptionQuery, Unit>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetExceptionQueryHandler"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public GetExceptionQueryHandler(
			ILogger<GetExceptionQueryHandler> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor) { }

		/// <inheritdoc/>
		public Task<Unit> Handle(GetExceptionQuery request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				throw new BadRequestException("Проверка обработки исключений");
				return Task.FromResult(Unit.Value);
			}
		}
	}
}
