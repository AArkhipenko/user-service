using MediatR;
using User.Service.Application.V10.User.DTO;

namespace User.Service.Application.V10.User.Queries
{
	/// <summary>
	/// Запрос на получение полной информации по пользователю
	/// </summary>
	public class GetFullUserQuery : IRequest<FullUserDTO>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetFullUserQuery"/> class.
		/// </summary>
		/// <param name="idUser"><inheritdoc cref="IdUser" path="/summary"/></param>
		public GetFullUserQuery(int idUser)
		{
			this.IdUser = idUser;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int IdUser { get; set; }
	}
}
