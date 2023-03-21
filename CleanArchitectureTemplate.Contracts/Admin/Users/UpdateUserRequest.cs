namespace CleanArchitecutreTemplate.Contracts.Admin.Users
{
    public record UpdateUserRequest(
        string FirstName,
        string LastName,
        string Email);
}
