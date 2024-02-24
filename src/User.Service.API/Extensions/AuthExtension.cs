using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddAuthJwt(this IServiceCollection services)
		{
			var jwtBearerBuilder = services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			});
			jwtBearerBuilder.AddJwtBearer(options =>
			 {
				 var key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
				 options.TokenValidationParameters = new TokenValidationParameters
				 {
					 ValidIssuer = "ExampleIssuer",
					 ValidAudience = "ExampleAudience",
					 ValidateIssuerSigningKey = true,
					 ValidateLifetime = true,
					 ClockSkew = TimeSpan.Zero,
					 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
				 };
			 });

			return services;
		}
	}
}
