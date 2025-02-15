using MediatR;
using User.Service.Application.V10.User.DTO;
using User.Service.Application.V10.User.Queries;
using User.Service.Domain.Interface.Repositories;

namespace User.Service.Application.V10.User.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="GetFullUserQuery"/>
	/// </summary>
	public class GetFullUserQueryHandler : IRequestHandler<GetFullUserQuery, FullUserDTO>
	{
		private readonly IUserRepository _userRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetFullUserQueryHandler"/> class.
		/// </summary>
		/// <param name="userRepository"><see cref="IUserRepository"/></param>
		public GetFullUserQueryHandler(IUserRepository userRepository)
		{
			this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		/// <inheritdoc/>
		public async Task<FullUserDTO> Handle(GetFullUserQuery request, CancellationToken cancellationToken)
		{
			var fullUser = await this._userRepository.GetFullUserAsync(request.IdUser);

			return new FullUserDTO
			{
				Id = fullUser.Id,
				UserTypeId = fullUser.UserTypeId,
				FirstName = fullUser.FirstName,
				SecondName = fullUser.SecondName,
				LastName = fullUser.LastName,
				BirthDay = fullUser.BirthDay,
				Email = fullUser.Email,
				Phone = fullUser.Phone,
			};
		}
	}
}
