using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class UserDetailDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
