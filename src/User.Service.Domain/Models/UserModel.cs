namespace User.Service.Domain.Models
{
	/// <summary>
	/// Модель пользователя
	/// </summary>
	public class UserModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserModel"/> class.
		/// </summary>
		/// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
		/// <param name="externalId"><inheritdoc cref="ExternalId" path="/summary"/></param>
		/// <param name="userTypeId"><inheritdoc cref="UserTypeId" path="/summary"/></param>
		public UserModel(int id, string externalId, int userTypeId)
		{
			this.Id = id;
			this.ExternalId = externalId;
			this.UserTypeId = userTypeId;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalId { get; }

		/// <summary>
		/// ИД типа пользователя
		/// </summary>
		public int UserTypeId { get; }
	}
}
