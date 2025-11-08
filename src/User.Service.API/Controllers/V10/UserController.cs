using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Service.Application.User.DTO;
using User.Service.Application.User.Queries;

namespace User.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер-пример
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("users/v{version:apiVersion}")]
	public class UserController : ApiAuthBaseController
	{
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserController"/> class.
		/// </summary>
		/// <param name="userProvider"><see cref="IUserProvider"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public UserController(
			IMediator mediator,
			ILogger<UserController> logger)
			: base(logger)
		{
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Получение информации по пользователю из токена
		/// </summary>
		/// <param name="cancellationToken">токен отмены</param>
		/// <returns><inheritdoc cref="TokenUserDto" path="/summary"/></returns>
		[HttpPost("get-user-by-token")]
		[Authorize("UserRole")]
		public async Task<ActionResult<TokenUserDto>> GetUserByTokenAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var result = await this._mediator.Send(
					new GetUserByTokenQuery(),
					cancellationToken);
				return Ok(result);
			}
		}
	}
}