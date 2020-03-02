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
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }
        public Guid? ManagedBy { get; set; }
        public string Name { get; set; }
        [ForeignKey("RoleId")]
        public RoleEntity RoleEntity { get; set; }

        public ICollection<TaskEntity> Task { get; set; }
        public ICollection<AttendanceEntity> Attendance { get; set; }
    }
}
