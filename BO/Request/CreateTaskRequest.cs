using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid AssignedTo { get; set; }
    }
}
