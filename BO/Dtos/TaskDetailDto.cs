using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class TaskDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Mark { get; set; }
        public string Note { get; set; }
        public DateTime NoteTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public string Updateby { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDone { get; set; }
        public int Status { get; set; }
    }
}
