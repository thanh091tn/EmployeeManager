using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using BO.Request;
using DAL;

namespace API.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult GetListUser()
        {
            var rs = _userLogic.GetListUserDetail();

            if (rs !=null)
            {
                return Ok(rs);
            }

            return NotFound();
        }
        [HttpGet("{userId}")]
        public IActionResult GetUser(string userId)
        {
            
            var b = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var rs = _userLogic.GetUserDetailById(b);

            if (rs != null)
            {
                return Ok(rs);
            }

            return NotFound();
        }


        [HttpPost("Login")]
        public IActionResult GetUser([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userLogic.Login(request.UserName, request.Password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        public IActionResult CreateUser([FromBody]CreateNewUserRequest request)
        {

            var rs = _userLogic.CreateUser(request);

            if (rs)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] CreateNewUserRequest request)
        {
            var rs = _userLogic.UpdateUser(request);

            if (rs)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpDelete("{userId}")]
        public IActionResult UpdateUser(string userId)
        {
            var rs = _userLogic.DeleteUserById(userId);

            if (rs)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}