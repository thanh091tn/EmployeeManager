using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class UserEntity
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleEntity RoleEntity { get; set; }

        public ICollection<UserManage> UserManages { get; set; }
        public ICollection<TaskEntity> Task { get; set; }
    }
}
