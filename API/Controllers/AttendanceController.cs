using System;
using System.Collections.Generic;
using System.Linq;
using BL.Interfaces;
using BO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceLogic _attendanceLogic;

        public AttendanceController(IAttendanceLogic attendanceLogic)
        {
            _attendanceLogic = attendanceLogic;
        }

        /*[HttpGet]
        public IActionResult GetAttendanceById(Guid taskId)
        {


            var task = _attendanceLogic.GetAttendanceByAttendanceId(taskId);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }*/

        [HttpGet("{userId}")]
        public IActionResult GetListAttendance(Guid userId)
        {
            var task = _attendanceLogic.GetListAttendance(userId);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        

        [HttpPut]
        public IActionResult CreateAttendance([FromBody]CreateAttendanceRequest request)
        {
            var task = _attendanceLogic.CreateAttendance(request);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateAttendance([FromBody]CreateAttendanceRequest request)
        {
            var task = _attendanceLogic.CreateAttendance(request);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteAttendance(Guid taskId)
        {
            var task = _attendanceLogic.DeleteAttendance(taskId);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}