﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Mark { get; set; }
        public string Note { get; set; }
        public DateTime? NoteTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public string Updateby { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDone { get; set; }
        public string Reason { get; set; }
        [ForeignKey("AssignedTo")]
        public UserEntity User { get; set; }

    }
}
