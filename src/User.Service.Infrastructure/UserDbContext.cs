using Microsoft.EntityFrameworkCore;
using User.Service.Infrastructure.Configurations;
using User.Service.Infrastructure.Configurations.Customer;
using User.Service.Infrastructure.Configurations.Public;
using User.Service.Infrastructure.Tables.Customer;
using User.Service.Infrastructure.Tables.Public;
using TableExt = User.Service.Infrastructure.Tables;

namespace User.Service.Infrastructure
{
	/// <summary>
	/// Контекст БД для схемы public
	/// </summary>
    internal class UserDbContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserDbContext"/> class.
		/// </summary>
		/// <param name="option"><see cref="DbContextOptions"/></param>
		public UserDbContext(DbContextOptions option)
			: base (option)
		{
		}

		/// <summary>
		/// Пользователи
		/// </summary>
		public DbSet<Tables.Customer.User> Users { get; set; }

		/// <summary>
		/// Типы пользователей
		/// </summary>
		public DbSet<UserType> UserTypes { get; set; }

		/// <summary>
		/// Личности пользователей
		/// </summary>
		public DbSet<Person> Persons { get; set; }

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PersonConfiguration());
		}
	}
}
