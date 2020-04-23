using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CinephilesChoice.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincpal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincpal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincpal.IsInRole("Cinephile"))
                {
                    context.Result = new RedirectToActionResult("Index", "Cinephiles", null);
                }
                else if (_claimsPrincpal.IsInRole("Admin"))
                {
                    context.Result = new RedirectToActionResult("Index", "Admins", null);
                }
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
