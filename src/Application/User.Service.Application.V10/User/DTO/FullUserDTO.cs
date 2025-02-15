namespace User.Service.Application.V10.User.DTO
{
	/// <summary>
	/// Молная модель пользователя (пользователь + личность)
	/// </summary>
	public class FullUserDTO
	{
		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД типа пользователя
		/// </summary>
		public int UserTypeId { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		public string? FirstName { get; set; }

		/// <summary>
		/// Отчество
		/// </summary>
		public string? SecondName { get; set; }

		/// <summary>
		/// Фамилия
		/// </summary>
		public string? LastName { get; set; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateOnly? BirthDay { get; set; }

		/// <summary>
		/// Электронная почта
		/// </summary>
		public string? Email { get; set; }

		/// <summary>
		/// Телефон
		/// </summary>
		public string? Phone { get; set; }
	}
}
