using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;

namespace BL.BusinessLogic
{
    public class AttendanceLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AttendanceLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public List<AttendanceDto> GetListAttendance(Guid userId)
        {
            try
            {
                var entity = _uow.GetRepository<AttendanceEntity>().GetAll().Where(c => c.Id == userId);
                var result = _mapper.Map<List<AttendanceDto>>(entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public bool CreateAttendance(CreateAttendanceRequest request)
        {
            try
            {
                var entity = _mapper.Map<AttendanceEntity>(request);
                _uow.GetRepository<AttendanceEntity>().Insert(entity);
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }

        public bool DeleteAttendance(Guid id)
        {
            try
            {
                var entity =  _uow.GetRepository<AttendanceEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<AttendanceEntity>().Delete(entity);
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool UpdateAttendance(CreateAttendanceRequest request)
        {
            try
            {
                var temp = _uow.GetRepository<AttendanceEntity>().GetAll().FirstOrDefault(c => c.Id == request.Id);
                var entity = _mapper.Map<AttendanceEntity>(request);
                temp.Date = request.Date;
                temp.StartTime = request.StartTime;
                temp.EndTime = request.EndTime;
                temp.UserId = request.UserId;
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}
