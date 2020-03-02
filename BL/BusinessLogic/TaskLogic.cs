using System;
using System.Collections;
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
using Microsoft.EntityFrameworkCore;
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
        public List<TaskDetailDto> GetListTaskByManagerId(Guid id)
        {
            try
            {
                var entity = new List<TaskEntity>();
                var roleid = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.Id == id).RoleId;
                if (roleid == 2) {
                var listUserid = new ArrayList();
                var list = _uow.GetRepository<UserEntity>().GetAll().Where(c => c.ManagedBy == id).ToList();
                foreach (var user in list)
                {
                    listUserid.Add(user.Id);
                }
                  entity = _uow.GetRepository<TaskEntity>().GetAll().Where(c => listUserid.Contains(c.AssignedTo)).ToList();
                }
                else if(roleid==3)
                {
                     entity = _uow.GetRepository<TaskEntity>().GetAll().ToList();
                }
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

        public bool DeleteTask(Guid id)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<TaskEntity>().Delete(entity);
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

        public bool UpdateTask(UpdateTaskRequest request)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == request.Id);
                var t = _mapper.Map<TaskEntity>(request);
                
                _uow.GetRepository<TaskEntity>().Delete(entity);
                _uow.GetRepository<TaskEntity>().Insert(t);
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
