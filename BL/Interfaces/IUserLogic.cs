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
        UserDetailDto GetUserDetailById(Guid id);
        bool UpdateUser(UpdateUserRequest request);
        bool DeleteUserById(Guid id);
    }
}
