namespace User.Service.Infrastructure.Tables
{
	/// <summary>
	/// Модель записи таблицы public.persons
	/// </summary>
	internal class Person
	{
		/// <summary>
		/// ИД записи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Связанная модель пользователя
		/// </summary>
		public virtual User User { get; set; }

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
