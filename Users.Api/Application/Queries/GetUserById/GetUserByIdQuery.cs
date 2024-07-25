using MediatR;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<User>
{
    public int Id { get; private set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}