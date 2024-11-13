﻿using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.Service.API.Authority;
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
			var keycloakSettings = configs.GetSection("KeycloakSettings").Get<KeycloakSettings>();
			if (keycloakSettings is null)
			{
				throw new Exception("Не найдена секция настройки JWT");
			}

			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.Authority = keycloakSettings.Authority;
					options.MetadataAddress = keycloakSettings.MetadataAddress;
					options.RequireHttpsMetadata = keycloakSettings.IsRequireHttpsMetadata;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = keycloakSettings.IsValidateIssuer,
						ValidIssuers = keycloakSettings.ValidIssuers,
						ValidateAudience = keycloakSettings.IsValidateAudience,
						ValidAudiences = keycloakSettings.ValidAudiences,
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminRole", policy =>
				{
					policy.AddRequirements(new RoleAccessPolicy(
						keycloakSettings.RequirementSettings.Service,
						keycloakSettings.RequirementSettings.AdminRole));
				});
				options.AddPolicy("UserRole", policy =>
				{
					policy.AddRequirements(new RoleAccessPolicy(
						keycloakSettings.RequirementSettings.Service,
						keycloakSettings.RequirementSettings.UserRole));
				});
			});

			services.AddTransient<IAuthorizationHandler, RoleAccessHandler>();

			return services;
		}
	}
}
