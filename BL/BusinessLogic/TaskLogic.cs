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
        private readonly UserHelper _userHelper;
        public TaskLogic( IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
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

        

        public List<TaskDetailDto> GetListTaskByUserId()
        {
            try
            {
                var uid = _userHelper.GetUserId();
                var entity = _uow.GetRepository<TaskEntity>().GetAll().Where(c => c.AssignedTo.Equals(uid));
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

        public List<TaskDetailDto> GetListTaskManager()
        {
            try
            {
                var uid = _userHelper.GetUserId();
                var e = _uow.GetRepository<UserManage>().GetAll().Where(c => c.ManagedBy == uid).ToList();
                var listid = new ArrayList();
                foreach (UserManage t in e)
                {
                    listid.Add(t.UserId);
                }
                
                var entity = _uow.GetRepository<TaskEntity>().GetAll().Where(c => listid.Contains(c.AssignedTo));
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

        public List<TaskDetailDto> GetListTaskAdmin()
        {
            try
            {
                
                var entity = _uow.GetRepository<TaskEntity>().GetAll().Where(c => c.IsApproved == false);
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


        public List<TaskDetailDto> GetListTaskByManagerId(string id)
        {
            try
            {
                var entity = new List<TaskEntity>();
                var roleid = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.Id == id).RoleId;
                if (roleid == 2) {
                var listUserid = new ArrayList();
                var list = _uow.GetRepository<UserManage>().GetAll().Where(c => c.ManagedBy == id).ToList();
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
                var uid = _userHelper.GetUserId();
                
                _uow.GetRepository<TaskEntity>().Insert(new TaskEntity
                {
                    Name = request.Name,
                    Description =  request.Description,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    CreatedBy = uid,
                    Updateby = uid,
                    UpdateTime = DateTime.Now,
                    AssignedTo = uid,
                    Status = 1
                    
                });
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
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


        public bool AssignTask(CreateTaskRequest request)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == request.id);
                var t = _mapper.Map<TaskEntity>(request);
                var uid = _userHelper.GetUserId();

                if (entity != null)
                {
                    entity.EndTime = request.EndTime;
                    entity.StartTime = request.StartTime;
                    entity.Name = request.Name;
                    entity.Description = request.Description;
                    entity.Updateby = uid;
                    entity.AssignedTo = request.AssignedTo;
                    _uow.GetRepository<TaskEntity>().Update(entity);
                    _uow.SaveChange();
                    return true;
                }
                else
                {
                    return false;
                }

                /*_uow.GetRepository<TaskEntity>().Delete(entity);
                _uow.GetRepository<TaskEntity>().Insert(t);*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateTask(CreateTaskRequest request)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == request.id);
                var t = _mapper.Map<TaskEntity>(request);
                var uid = _userHelper.GetUserId();
                
                if (entity != null)
                {
                    entity.EndTime = request.EndTime;
                    entity.StartTime = request.StartTime;
                    entity.Name = request.Name;
                    entity.Description = request.Description;
                    entity.Updateby = uid;
                    entity.UpdateTime = DateTime.Now;
                    _uow.GetRepository<TaskEntity>().Update(entity);
                    _uow.SaveChange();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AproveTask(Guid taskId, bool isapprove)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == taskId);
                if(isapprove)
                entity.IsApproved = isapprove;
                entity.UpdateTime = DateTime.Now;
                entity.Updateby = _userHelper.GetUserId();
                entity.Status = 2;
                _uow.GetRepository<TaskEntity>().Update(entity);
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
        public bool FinishTask(Guid taskId,  bool isdone)
        {
            try
            {
                var entity = _uow.GetRepository<TaskEntity>().GetAll().FirstOrDefault(c => c.Id == taskId);
                
                entity.IsDone = isdone;
                entity.UpdateTime = DateTime.Now;
                entity.Updateby = _userHelper.GetUserId();
                entity.Status = 3;
                _uow.GetRepository<TaskEntity>().Update(entity);
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }
    }
}
