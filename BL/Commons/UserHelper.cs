using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace BL.Commons
{
    public class UserHelper : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserId()
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return "";
            }
            return userId;
        }
    }
}
