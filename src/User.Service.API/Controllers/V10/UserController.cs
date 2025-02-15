using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Service.Application.V10.User.DTO;
using User.Service.Application.V10.User.Queries;
using User.Service.Domain.Core.UserHelper;

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
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public UserController(
			IUserHelper userHelper,
			IMediator mediator,
			ILogger<UserController> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
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