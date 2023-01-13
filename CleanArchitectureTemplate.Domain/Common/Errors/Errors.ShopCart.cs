using ErrorOr;

namespace CleanArchitecutreTemplate.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class ShopCart
        {
            public static Error NotFoundItem => Error.NotFound(
                code: "ShopCartItem.NotFound",
                description: "Item not found in shopping cart.");
        
            public static Error ShopCartEmpty => Error.Conflict(
                code: "ShopCart.Empty",
                description: "Shopping cart is empty.");
        }
    }
}