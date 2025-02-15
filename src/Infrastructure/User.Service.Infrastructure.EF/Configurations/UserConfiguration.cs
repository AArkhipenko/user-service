using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Configurations
{
	/// <summary>
	/// Настройка отображения таблицы на модель
	/// </summary>
	internal class UserConfiguration : IEntityTypeConfiguration<TableExt.User>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<TableExt.User> builder)
		{
			builder.ToTable("users", "public")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(p => p.ExternalId)
				.HasColumnName("external_id")
				.IsRequired();

			builder
				.Property<int>(p => p.UserTypeId)
				.HasColumnName("user_type_id")
				.IsRequired();

			builder
				.HasOne(x => x.UserType)
				.WithOne()
				.HasForeignKey<TableExt.User>(x => x.UserTypeId);
		}
	}
}
