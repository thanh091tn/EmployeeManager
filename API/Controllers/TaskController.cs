using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using BO.Request;
using DAL;

namespace API.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskLogic _taskLogic;

        public TaskController(ITaskLogic taskLogic)
        {
            _taskLogic = taskLogic;
        }

        

        [HttpGet]
        public IActionResult GetListTaskByUserId()
        {
            var task = _taskLogic.GetListTaskByUserId();

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        [HttpGet("GetListTaskManager")]
        public IActionResult GetListTaskManager()
        {
            var task = _taskLogic.GetListTaskManager();

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        [HttpGet("GetListTaskAdmin")]
        public IActionResult GetListTaskAdmin()
        {
            var task = _taskLogic.GetListTaskAdmin();

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut]
        public IActionResult CreateTask([FromBody]CreateTaskRequest request)
        {
            var task = _taskLogic.CreateTask(request);

            if (task==true)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateTask([FromBody]CreateTaskRequest request)
        {
            var task = _taskLogic.UpdateTask(request);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost("UpdateTaskAdmin")]
        public IActionResult UpdateTaskAdmin([FromBody]CreateTaskRequest request)
        {
            var task = _taskLogic.AssignTask(request);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("Approve")]
        public IActionResult ApproveTask(Guid taskId,bool isapprove)
        {
            var task = _taskLogic.AproveTask(taskId,isapprove);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpGet("Finish")]
        public IActionResult FinishTask(Guid taskId, bool isdone)
        {
            var task = _taskLogic.FinishTask(taskId, isdone);
            if (task)
            {
                return Ok();
            }

            return NotFound();
        }



        [HttpDelete]
        public IActionResult DeleteTask(Guid taskId)
        {
            var task = _taskLogic.DeleteTask(taskId);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}