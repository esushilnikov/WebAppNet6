using MediatR;

namespace Application.Features.User.Queries;

public class GetUserQuery : IRequest<UserDetailsVm>
{
    public int UserId { get; set; }
}