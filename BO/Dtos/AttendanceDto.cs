using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
