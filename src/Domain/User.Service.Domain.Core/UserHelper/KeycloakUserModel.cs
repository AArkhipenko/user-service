using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace User.Service.Domain.Core.UserHelper
{
	/// <summary>
	/// Модель пользователя из системы Keycloak
	/// </summary>
	public class KeycloakUserModel
	{
		private KeycloakUserModel(string externalId)
		{
			this.ExternalId = externalId;
		}

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalId { get; }

		/// <summary>
		/// Создание модели из контекста запроса
		/// </summary>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <returns><inheritdoc cref="KeycloakUserModel" path="/summary"/></returns>
		public static KeycloakUserModel CreateModel(IHttpContextAccessor contextAccessor)
		{
			var sub = contextAccessor.HttpContext.User.Claims.Where(claim => claim.Type == "sub").FirstOrDefault();
			if (sub is null)
			{
				throw new Exception("Не найден раздел resource_access");
			}

			return new KeycloakUserModel(sub.Value);
		}
	}
}
