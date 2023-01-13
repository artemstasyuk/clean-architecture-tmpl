namespace CleanArchitecutreTemplate.Contracts.Admin.Users
{
    public record UserResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        Balance Balance,
        string Role);

    public record Balance(
        string Currency,
        decimal Amount);
}