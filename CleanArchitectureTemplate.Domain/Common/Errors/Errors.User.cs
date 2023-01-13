using ErrorOr;

namespace CleanArchitecutreTemplate.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already in use.");
            
            public static Error AdminCannotBeDeleted => Error.Conflict(
                code: "User.AdminCannotBeDeleted",
                description: "You cannot delete admins in the administration system.");
        
            public static Error NotFound => Error.NotFound(
                code: "User.NotFound",
                description: "Not found user in database.");
        
            public static Error NotEnoughBalance => Error.Validation(
                code: "User.NotEnoughBalance",
                description: "Not enough balance on account.");
        }
    }
}