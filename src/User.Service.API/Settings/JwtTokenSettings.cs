namespace User.Service.API.Settings
{
	/// <summary>
	/// Найстройки для конфигурирования JWT
	/// </summary>
	public class JwtTokenSettings
	{
		/// <summary>
		/// Секретный ключ
		/// </summary>
		public string SecretKey { get; set; } = string.Empty;

		/// <summary>
		/// ???
		/// </summary>
		public string Issuer { get; set; } = string.Empty;

		/// <summary>
		/// ???
		/// </summary>
		public string Audience { get; set; } = string.Empty;
	}
}
