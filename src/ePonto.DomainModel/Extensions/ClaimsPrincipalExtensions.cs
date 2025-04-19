using System.Security.Claims;

namespace ePonto.Extensions;

public static class ClaimsPrincipalExtensions
{
    //public static TransactionContext CreateTransaction(this ClaimsPrincipal user)
    //{
    //    var userId = user.GetUserId();

    //    var transaction = new TransactionContext(userId);

    //    return transaction;
    //}

    public static string GetUserId(this ClaimsPrincipal user)
    {
        var nameIdentifier = user.FindFirst(ClaimTypes.NameIdentifier);

        var userId = nameIdentifier.Value;

        return userId;
    }
}
