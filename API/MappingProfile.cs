using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BO.Dtos;
using BO.Models;
using BO.Request;


namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TaskEntity, CreateTaskRequest>();
            CreateMap<CreateTaskRequest, TaskEntity>();
            CreateMap<TaskEntity, TaskDetailDto>();
            CreateMap<TaskDetailDto, TaskEntity>();
            CreateMap<TaskEntity, UpdateTaskRequest>();
            CreateMap<UpdateTaskRequest, TaskEntity>();
            CreateMap<UserEntity, CreateNewUserRequest>();
            CreateMap<CreateNewUserRequest, UserEntity>();
            CreateMap<UserEntity, UserDetailDto>();
            CreateMap<UserDetailDto, UserEntity>();

        }
    }
}
