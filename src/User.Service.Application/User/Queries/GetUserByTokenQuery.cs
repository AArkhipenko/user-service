using MediatR;
using User.Service.Application.User.DTO;

namespace User.Service.Application.User.Queries
{
	/// <summary>
	/// Запрос на получение информации по пользователю из токена
	/// </summary>
	public class GetUserByTokenQuery : IRequest<TokenUserDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetUserByTokenQuery"/> class.
		/// </summary>
		public GetUserByTokenQuery()
		{ }
	}
}
