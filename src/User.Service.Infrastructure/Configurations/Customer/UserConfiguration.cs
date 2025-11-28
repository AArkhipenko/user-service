using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace User.Service.Infrastructure.Configurations.Customer
{
	/// <summary>
	/// Настройка отображения таблицы на модель
	/// </summary>
	internal class UserConfiguration : IEntityTypeConfiguration<Tables.Customer.User>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<Tables.Customer.User> builder)
		{
			builder.ToTable("users", "customer")
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
				.HasForeignKey<Tables.Customer.User>(x => x.UserTypeId);
		}
	}
}
