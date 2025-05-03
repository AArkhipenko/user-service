namespace User.Service.Infrastructure.Tables
{
	/// <summary>
	/// Модель записи таблицы public.user_types
	/// </summary>
	internal class UserType
	{
		/// <summary>
		/// ИД записи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название типа
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Код типа
		/// </summary>
		public string Code { get; set; }
	}
}
