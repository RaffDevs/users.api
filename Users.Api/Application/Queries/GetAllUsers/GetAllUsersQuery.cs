using MediatR;
using Users.Api.Core.Entities;

namespace Users.Api.Application.Queries.GetAllUsers;

public class GetAllUsersQuery :  IRequest<List<User>>
{
    
}