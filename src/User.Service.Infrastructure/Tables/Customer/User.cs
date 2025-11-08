using User.Service.Infrastructure.Tables.Public;

namespace User.Service.Infrastructure.Tables.Customer
{
	/// <summary>
	/// Модель записи таблицы public.users
	/// </summary>
	internal class User
	{
		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalId { get; set; }

		/// <summary>
		/// ИД типа пользователя
		/// </summary>
		public int UserTypeId { get; set; }

		/// <summary>
		/// Модель типа пользователя
		/// </summary>
		public virtual UserType UserType { get; set; }
	}
}
