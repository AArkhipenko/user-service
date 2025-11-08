using AArkhipenko.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.Service.Domain.Models;
using User.Service.Domain.Repositories;

namespace User.Service.Infrastructure.Repositories
{
	/// <summary>
	/// Реализация <see cref="IUserRepository"/>
	/// </summary>
	internal class UserRepository : IUserRepository
	{
		private readonly UserDbContext _context;
		private readonly ILogger<UserRepository> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="UserDbContext"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public UserRepository(
			UserDbContext context,
			ILogger<UserRepository> logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		/// <inheritdoc/>
		public async Task<UserModel> GetUserByExternalIdAsync(string externalId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			
			var userDb = await this._context.Users
				.Where(x => x.ExternalId == externalId)
				.FirstOrDefaultAsync(cancellationToken);
			if (userDb is null)
			{
				var message = $"Не найден пользователь с id={externalId}";
				this._logger.LogError(message);
				throw new NotFoundException(message);
			}

			return new UserModel(
				userDb.Id,
				userDb.ExternalId,
				userDb.UserTypeId);
		}
	}
}
