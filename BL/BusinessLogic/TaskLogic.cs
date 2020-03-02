using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Commons;
using BL.Helpers;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;
using Microsoft.Extensions.Options;

namespace BL.BusinessLogic
{
    public class TaskLogic : ITaskLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TaskLogic( IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public TaskDetailDto GetTaskByTaskId(Guid id)
        {
            try
            {

                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                var result = _mapper.Map<TaskDetailDto>(entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return null;
        }

        public List<TaskDetailDto> GetListTaskByUserId(Guid id)
        {
            try
            {

                var entity = _uow.GetRepository<TaskEntity>().GetAll().Where(c => c.AssignedTo == id);
                var result = _mapper.Map<List<TaskDetailDto>>(entity);
                
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return null;
        }

        public bool CreateTask(CreateTaskRequest request)
        {
            try
            {
                var entity = _mapper.Map<TaskEntity>(request);
                _uow.GetRepository<TaskEntity>().Insert(entity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }

        public bool DeleteTask(Guid id)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<TaskEntity>().Delete(entity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }

        public bool UpdateTask(UpdateTaskRequest request)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == request.Id);
                var t = _mapper.Map<TaskEntity>(request);
                entity = t;
                _uow.GetRepository<TaskEntity>().Update(entity);
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }
    }
}
