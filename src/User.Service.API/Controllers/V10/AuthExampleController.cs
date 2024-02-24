using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using User.Service.Application.V10.Example.Queries;

namespace User.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер-пример
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("auth-examples/v{version:apiVersion}")]
	public class AuthExampleController : ApiAuthBaseController
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AuthExampleController"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public AuthExampleController(
			ILogger<ExampleController> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
        {
		}

		/// <summary>
		/// Тестовый метод получения данных
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список случайных чисел</returns>
		[HttpGet]
        public Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
			using(_ = base.BeginLoggingScope())
			{
				return Task.FromResult<IActionResult>(Ok());
			}
		}
	}
}