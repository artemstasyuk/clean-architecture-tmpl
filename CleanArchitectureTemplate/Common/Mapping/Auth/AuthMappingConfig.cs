using CleanArchitectureTemplate.Application.Authentication.Commands.Register;
using CleanArchitectureTemplate.Application.Authentication.Common;
using CleanArchitectureTemplate.Application.Authentication.Queries.Login;
using CleanArchitecutreTemplate.Contracts.Authentication;
using Mapster;

namespace CleanArchitectureTemplate.Api.Common.Mapping.Auth;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        
        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.Role, src => src.User.Role.ToString())
            .Map(dest => dest, src => src.User);
    }
}