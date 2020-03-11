using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public List<string> ListEmployee { get; set; }
        public string ManagedBy { get; set; }
        public string Name { get; set; }
    }
}
