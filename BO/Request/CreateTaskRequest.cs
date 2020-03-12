using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CreateTaskRequest
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string userid { get; set; }
        public string AssignedTo { get; set; }
    }
}
