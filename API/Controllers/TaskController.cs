﻿using System;
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
        public IActionResult GetTaskById(Guid taskId)
        {
            

            var task = _taskLogic.GetTaskByTaskId(taskId);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("GetTaskbyUserId")]
        public IActionResult GetListTaskByUserId(Guid userid)
        {
            var task = _taskLogic.GetListTaskByUserId(userid);

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

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateTask([FromBody]UpdateTaskRequest request)
        {
            var task = _taskLogic.UpdateTask(request);

            if (task)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        public IActionResult UpdateTask(Guid taskId)
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