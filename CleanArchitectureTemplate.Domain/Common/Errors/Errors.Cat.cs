using ErrorOr;

namespace CleanArchitecutreTemplate.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Cat
        {
            public static Error NotFound => Error.NotFound(
                code: "Cat.NotFound",
                description: "Cat not found in database.");
        
            public static Error AlreadyExist => Error.Validation(
                code: "Cat.AlreadyExist",
                description: "Cat already exist in shopCart.");
        }
    }
}