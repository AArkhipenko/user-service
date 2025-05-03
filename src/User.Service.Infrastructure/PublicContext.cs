using Microsoft.EntityFrameworkCore;
using User.Service.Infrastructure.Configurations;
using TableExt = User.Service.Infrastructure.Tables;

namespace User.Service.Infrastructure
{
	/// <summary>
	/// Контекст БД для схемы public
	/// </summary>
    internal class PublicContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PublicContext"/> class.
		/// </summary>
		/// <param name="option"><see cref="DbContextOptions"/></param>
		public PublicContext(DbContextOptions option)
			: base (option)
		{
		}

		/// <summary>
		/// Пользователи
		/// </summary>
		public DbSet<TableExt.User> Users { get; set; }

		/// <summary>
		/// Типы пользователей
		/// </summary>
		public DbSet<TableExt.UserType> UserTypes { get; set; }

		/// <summary>
		/// Личности пользователей
		/// </summary>
		public DbSet<TableExt.Person> Persons { get; set; }

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
			modelBuilder.ApplyConfiguration(new PersonConfiguration());
		}
	}
}
