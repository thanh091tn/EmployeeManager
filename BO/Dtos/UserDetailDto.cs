using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class UserDetailDto
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
