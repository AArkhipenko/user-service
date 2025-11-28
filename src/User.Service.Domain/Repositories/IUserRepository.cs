using User.Service.Domain.Models;

namespace User.Service.Domain.Repositories
{
	/// <summary>
	/// Репозиторий для работы с пользователями системы
	/// </summary>
    public interface IUserRepository
    {
		/// <summary>
		/// Получение информации о пользователе по ИД во внешней системе
		/// </summary>
		/// <param name="externalId">ИД пользователя во внешней системе</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns><inheritdoc cref="UserModel" path="/summary"/></returns>
		Task<UserModel> GetUserByExternalIdAsync(string externalId, CancellationToken cancellationToken);
    }
}
