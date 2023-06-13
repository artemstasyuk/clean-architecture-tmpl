using CleanArchitectureTemplate.Application.Users.Commands.UpdateUser;
using CleanArchitecutreTemplate.Contracts.Admin.Users;
using CleanArchitecutreTemplate.Domain.UserAggregate;
using Mapster;

namespace CleanArchitectureTemplate.Api.Common.Mapping.Users;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UpdateUserRequest, UpdateUserCommand>();

        config.NewConfig<User, UserResponse>()
            .Map(dist => dist.Id, src => src.Id.Value)
            .Map(dist => dist.Role, src => src.Role.ToString());
    }
}