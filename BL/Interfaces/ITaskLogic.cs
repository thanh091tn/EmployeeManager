using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ITaskLogic
    {
        TaskDetailDto GetTaskByTaskId(Guid id);
        List<TaskDetailDto> GetListTaskByUserId(Guid id);
        bool CreateTask(CreateTaskRequest request);
        bool DeleteTask(Guid id);
        bool UpdateTask(UpdateTaskRequest request);
    }
}
