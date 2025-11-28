using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Service.Infrastructure.Tables.Public;

namespace User.Service.Infrastructure.Configurations.Public
{
	/// <summary>
	/// Настройка отображения таблицы на модель
	/// </summary>
	internal class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<UserType> builder)
		{
			builder.ToTable("user_types", "public")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(p => p.Name)
				.HasColumnName("name")
				.IsRequired();

			builder
				.Property<string>(p => p.Code)
				.HasColumnName("code")
				.IsRequired();
		}
	}
}
