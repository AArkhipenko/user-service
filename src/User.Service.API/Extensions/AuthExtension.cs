using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.Service.API.Settings;

namespace User.Service.API.Extensions
{
	/// <summary>
	/// Добавление настроек для работы с аутентификацией
	/// </summary>
	internal static class AuthExtension
	{
		/// <summary>
		/// Добавления настроект для аутентификации при помощи JWT
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configs"><see cref="ConfigurationManager"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddAuthJwt(this IServiceCollection services, ConfigurationManager configs)
		{
			var jwtTokenSettings = configs.GetSection("JwtTokenSettings").Get<JwtTokenSettings>();
			if(jwtTokenSettings is null)
			{
				throw new Exception("Не найдена секция настройки JWT");
			}

			var jwtBearerBuilder = services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			});

			jwtBearerBuilder.AddJwtBearer(options =>
			 {
				 options.TokenValidationParameters = new TokenValidationParameters
				 {
					 ValidIssuer = jwtTokenSettings.Issuer,
					 ValidAudience = jwtTokenSettings.Audience,
					 ValidateIssuerSigningKey = true,
					 ValidateLifetime = true,
					 ClockSkew = TimeSpan.Zero,
					 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSettings.SecretKey))
				 };
			 });

			return services;
		}
	}
}
