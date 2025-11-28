namespace User.Service.Application.User.DTO
{
	/// <summary>
	/// Пользователь из токена
	/// </summary>
	public class TokenUserDto
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
	}
}
