using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;

namespace BL.Interfaces
{
    public interface IUserLogic
    {
        UserDetailDto Login(string userid, string password);
    }
}
