using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IAttendanceLogic
    {
        List<AttendanceDto> GetListAttendance(Guid userId);
        bool CreateAttendance(CreateAttendanceRequest request);
        bool DeleteAttendance(Guid id);
        bool UpdateAttendance(CreateAttendanceRequest request);
    }
}
