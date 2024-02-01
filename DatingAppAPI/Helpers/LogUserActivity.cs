﻿using DatingAppAPI.Extensions;
using DatingAppAPI.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DatingAppAPI.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return;
            }

            var userId = resultContext.HttpContext.User.GetUserId();
            var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var user = await repo.UserRepository.GetById(Guid.Parse(userId));

            user.LastActive = DateTime.UtcNow;
            await repo.Complete();
        }
    }
}