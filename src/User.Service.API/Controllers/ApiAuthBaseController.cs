﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using User.Service.Domain.Core.Logging;

namespace User.Service.API.Controllers
{
	/// <summary>
	/// Базовый контроллер для всех контроллеров
	/// Реализует <see cref="ILoggerWrapper"/>
	/// </summary>
	[Authorize]
	public abstract class ApiAuthBaseController : ApiBaseController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApiAuthBaseController"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		protected ApiAuthBaseController(
			ILogger logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
		{
		}
	}
}
