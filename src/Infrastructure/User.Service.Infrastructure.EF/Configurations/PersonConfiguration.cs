using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Configurations
{
	/// <summary>
	/// Настройка отображения таблицы на модель
	/// </summary>
	internal class PersonConfiguration : IEntityTypeConfiguration<TableExt.Person>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<TableExt.Person> builder)
		{
			builder.ToTable("persons", "public")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.HasOne(x => x.User)
				.WithOne()
				.HasForeignKey<TableExt.Person>(x => x.Id);

			builder
				.Property<string?>(p => p.FirstName)
				.HasColumnName("first_name");

			builder
				.Property<string?>(p => p.SecondName)
				.HasColumnName("second_name");

			builder
				.Property<string?>(p => p.LastName)
				.HasColumnName("last_name");

			builder
				.Property<DateOnly?>(p => p.BirthDay)
				.HasColumnName("birthday");

			builder
				.Property<string?>(p => p.Email)
				.HasColumnName("email");

			builder
				.Property<string?>(p => p.Phone)
				.HasColumnName("phone");
		}
	}
}
