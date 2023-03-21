namespace CleanArchitecutreTemplate.Contracts.Admin.Users
{
    public record UserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Role);
}