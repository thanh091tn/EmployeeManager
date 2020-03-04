using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CreateAttendanceRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
