using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
namespace BL.Helpers
{
    public class UserHelpers : ControllerBase
    {
        public string GetUserId()
        {
            var b = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return b;
        }
    }
}
