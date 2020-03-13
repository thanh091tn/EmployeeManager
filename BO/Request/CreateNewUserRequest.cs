using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CreateNewUserRequest
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
