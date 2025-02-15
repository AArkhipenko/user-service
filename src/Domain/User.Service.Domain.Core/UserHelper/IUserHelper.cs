namespace User.Service.Domain.Core.UserHelper
{
	/// <summary>
	/// Интерфейс для работы с пользователями в системе
	/// </summary>
	public interface IUserHelper
	{
		/// <summary>
		/// Получение модели пользователя
		/// </summary>
		/// <returns><see cref="UserModel"/></returns>
		Task<UserModel> GetUserAsync();
	}
}
