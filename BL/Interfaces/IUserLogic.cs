using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IUserLogic
    {
        UserDetailDto Login(string userid, string password);
        bool CreateUser(CreateNewUserRequest request);
        List<UserDetailDto> GetListUserDetail();
        UserDetailDto GetUserDetailById(string id);
        bool UpdateUser(CreateNewUserRequest request);
        bool DeleteUserById(string id);
    }
}
