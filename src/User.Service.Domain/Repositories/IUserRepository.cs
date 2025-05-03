using User.Service.Domain.Models;

namespace User.Service.Domain.Repositories
{
	/// <summary>
	/// Репозиторий для работы с пользователями системы
	/// </summary>
    public interface IUserRepository
    {
		/// <summary>
		/// Получение полной информации по пользователю
		/// </summary>
		/// <param name="userId">ИД пользователя</param>
		/// <returns><inheritdoc cref="FullUserModel" path="/summary"/></returns>
		Task<FullUserModel> GetFullUserAsync(int userId);
    }
}
