using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Service.Application.User.DTO;
using User.Service.Application.User.Queries;
using User.Service.Domain.UserHelper;

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
		private readonly IUserHelper _userHelper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserController"/> class.
		/// </summary>
		/// <param name="userHelper"><see cref="IUserHelper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public UserController(
			IUserHelper userHelper,
			IMediator mediator,
			ILogger<UserController> logger)
			: base(logger)
		{
			this._userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Получение информации о пользователе по информации из токена
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns><inheritdoc cref="FullUserDTO" path="/summary"/></returns>
		[HttpPost("get-full-user")]
		[Authorize("UserRole")]
		public async Task<ActionResult<FullUserDTO>> GetFullUserAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userHelper.GetUserAsync();
				var result = await this._mediator.Send(new GetFullUserQuery(user.Id));
				return Ok(result);
			}
		}
	}
}