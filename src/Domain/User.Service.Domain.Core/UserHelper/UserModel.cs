namespace User.Service.Domain.Core.UserHelper
{
	/// <summary>
	/// Модель пользователя из системы
	/// </summary>
	public class UserModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserModel"/> class.
		/// </summary>
		/// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
		public UserModel(int id)
		{
			this.Id = id;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; }
	}
}
