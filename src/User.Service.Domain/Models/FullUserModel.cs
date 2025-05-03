namespace User.Service.Domain.Models
{
	/// <summary>
	/// Полная модель пользователя
	/// </summary>
	public class FullUserModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FullUserModel"/> class.
		/// </summary>
		/// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
		/// <param name="userTypeId"><inheritdoc cref="UserTypeId" path="/summary"/></param>
		/// <param name="firstName"><inheritdoc cref="FirstName" path="/summary"/></param>
		/// <param name="secondName"><inheritdoc cref="SecondName" path="/summary"/></param>
		/// <param name="lastName"><inheritdoc cref="LastName" path="/summary"/></param>
		/// <param name="birthDay"><inheritdoc cref="BirthDay" path="/summary"/></param>
		/// <param name="email"><inheritdoc cref="Email" path="/summary"/></param>
		/// <param name="phone"><inheritdoc cref="Phone" path="/summary"/></param>
		public FullUserModel(int id, int userTypeId, string? firstName, string? secondName, string? lastName, DateOnly? birthDay, string? email, string? phone)
		{
			this.Id = id;
			this.UserTypeId = userTypeId;
			this.FirstName = firstName;
			this.SecondName = secondName;
			this.LastName = lastName;
			this.BirthDay = birthDay;
			this.Email = email;
			this.Phone = phone;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// ИД типа пользователя
		/// </summary>
		public int UserTypeId { get; }

		/// <summary>
		/// Имя
		/// </summary>
		public string? FirstName { get; }

		/// <summary>
		/// Отчество
		/// </summary>
		public string? SecondName { get; }

		/// <summary>
		/// Фамилия
		/// </summary>
		public string? LastName { get; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateOnly? BirthDay { get; }

		/// <summary>
		/// Электронная почта
		/// </summary>
		public string? Email { get; }

		/// <summary>
		/// Телефон
		/// </summary>
		public string? Phone { get; }
	}
}
