using api.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Helpers;

// client => api => Controller (Request.HttpContext) => 
// AccountRepository => DB => AccountRepository => 
// Controller (HttpContext.Response) => client

public class LogUserActivity(ILogger<LogUserActivity> _logger) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        ActionExecutedContext? resultNext = await next(); // After api's processing is done. 
        // Use 'context' instead of 'next' for before api's processing.

        if (resultNext is null) return;

        // return if User is NOT authenticated
        if (resultNext.HttpContext.User.Identity is not null && !resultNext.HttpContext.User.Identity.IsAuthenticated)
            return;

        string? loggedInUserId = resultNext.HttpContext.User.GetUserId();

        if (string.IsNullOrEmpty(loggedInUserId))
        {
            _ = loggedInUserId ?? throw new ArgumentException("Parameter cannot be null", nameof(loggedInUserId));
            return;
        }   

        IAccountRepository? accountRepository = resultNext.HttpContext.RequestServices.GetRequiredService<IAccountRepository>();

        if (accountRepository is null) return;

        CancellationToken cancellationToken = resultNext.HttpContext.RequestAborted; // access cancellationToken

        UpdateResult? result  = await accountRepository.UpdateLastActive(loggedInUserId, cancellationToken);

        if (result is null || result.ModifiedCount == 0)
            _logger.LogError("Update lastActive in db failed. Check LogUserActivity.cs");
    }
}
