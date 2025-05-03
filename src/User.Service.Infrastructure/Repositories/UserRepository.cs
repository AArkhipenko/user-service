using AArkhipenko.Core.Exceptions;
using User.Service.Domain.Models;
using User.Service.Domain.Repositories;

namespace User.Service.Infrastructure.Repositories
{
	/// <summary>
	/// Реализация <see cref="IUserRepository"/>
	/// </summary>
	internal class UserRepository : IUserRepository
	{
		private readonly PublicContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="PublicContext"/></param>
		public UserRepository(PublicContext context)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
		}

		/// <inheritdoc/>
		public async Task<FullUserModel> GetFullUserAsync(int userId)
		{
			var userDb = await this._context.Users.FindAsync(userId);
			if (userDb is null)
			{
				throw new NotFoundException($"Не найден пользователь с id={userId}");
			}

			var personDb = await this._context.Persons.FindAsync(userId);
			if (personDb is null)
			{
				throw new NotFoundException($"Не найдена персональная информация для пользователя с id={userId}");
			}

			return new FullUserModel(
				userDb.Id,
				userDb.UserTypeId,
				personDb.FirstName,
				personDb.SecondName,
				personDb.LastName,
				personDb.BirthDay,
				personDb.Email,
				personDb.Phone);
		}
	}
}
