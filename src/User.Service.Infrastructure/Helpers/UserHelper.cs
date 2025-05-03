using AArkhipenko.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using User.Service.Domain.UserHelper;

namespace User.Service.Infrastructure.Helpers
{
	/// <summary>
	/// Реализация <see cref="IUserHelper"/>
	/// </summary>
	internal class UserHelper : IUserHelper
	{
		private UserModel _user;
		private readonly KeycloakUserModel _keycloakUser;

		private readonly PublicContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserHelper"/> class.
		/// </summary>
		/// <param name="context"><see cref="PublicContext"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public UserHelper(
			PublicContext context,
			IHttpContextAccessor contextAccessor)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._keycloakUser = KeycloakUserModel.CreateModel(contextAccessor);
		}

		/// <inheritdoc/>
		public async Task<UserModel> GetUserAsync()
		{
			if (this._user is not null)
			{
				return this._user;
			}

			var userDb = await this._context.Users
				.Where(x => x.ExternalId == this._keycloakUser.ExternalId)
				.FirstOrDefaultAsync();

			if (userDb is null)
			{
				throw new NotFoundException($"Не найден пользователь с внешним ИД = {this._keycloakUser.ExternalId}");
			}

			this._user = new UserModel(userDb.Id);

			return this._user;
		}
	}
}
