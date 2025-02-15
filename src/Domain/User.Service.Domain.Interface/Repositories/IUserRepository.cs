using User.Service.Domain.Interface.Models;

namespace User.Service.Domain.Interface.Repositories
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
