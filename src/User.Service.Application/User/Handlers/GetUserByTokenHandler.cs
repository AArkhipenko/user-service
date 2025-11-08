using System.Security.Claims;
using AArkhipenko.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using User.Service.Application.User.DTO;
using User.Service.Application.User.Queries;
using User.Service.Domain.Repositories;

namespace User.Service.Application.User.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="GetUserByTokenQuery"/>
	/// </summary>
	public class GetUserByTokenHandler : IRequestHandler<GetUserByTokenQuery, TokenUserDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly ILogger<GetUserByTokenHandler> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetUserByTokenHandler"/> class.
		/// </summary>
		/// <param name="userRepository"><see cref="IUserRepository"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public GetUserByTokenHandler(
			IUserRepository userRepository,
			IHttpContextAccessor contextAccessor,
			ILogger<GetUserByTokenHandler> logger)
		{
			this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			this._contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc/>
		public async Task<TokenUserDto> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			
			var externalId = this.GetExternalId();
			var userModel = await this._userRepository.GetUserByExternalIdAsync(externalId, cancellationToken);

			return new TokenUserDto
			{
				Id = userModel.Id,
				ExternalId = userModel.ExternalId,
				UserTypeId = userModel.UserTypeId,
			};
		}

		/// <summary>
		/// Получение ИД пользователя во внешней системе из токена
		/// </summary>
		/// <returns>ИД пользователя во внешней системе</returns>
		private string GetExternalId()
		{
			if (this._contextAccessor.HttpContext is null)
			{
				var message = "Не задан контекст запроса";
				this._logger.LogError(message);
				throw new HttpRequestException(message);
			}
			else if (!this._contextAccessor.HttpContext.User.HasClaim(x => x.Type == Consts.ClaimUserId))
			{
				var message = $"Identity не содержит информации о {Consts.ClaimUserId}";
				this._logger.LogError(message);
				throw new AuthorizationException(message);
			}

			var externalId = this._contextAccessor.HttpContext.User.FindFirstValue(Consts.ClaimUserId);
			if (string.IsNullOrEmpty(externalId))
			{
				var message = $"{Consts.ClaimUserId} не задан";
				this._logger.LogError(message);
				throw new AuthorizationException(message);
			}
			
			return externalId;
		}
	}
}
