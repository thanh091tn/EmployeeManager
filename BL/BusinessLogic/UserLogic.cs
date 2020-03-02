using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BL.Commons;
using BL.Helpers;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using DAL.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BL.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserHelper _userHelper;

        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;


        public UserLogic(IOptions<AppSettings> appSettings, UserHelper userHelper, IUnitOfWork uow)
        {

            _userHelper = userHelper;

            _uow = uow;
            _appSettings = appSettings.Value;
        }

        //business logic Login
        public UserDetailDto Login(string userid, string password)
        {


            var User = _uow.GetRepository<UserEntity>().GetAll().Include(c => c.RoleEntity)
                .FirstOrDefault(user => Equals(user.UserName, userid) && user.Password == password);

            if (User == null)
            {
                return null;
            }

            return new UserDetailDto
            {
                Id = User.Id,
                Name = User.Name,
                RoleId = User.RoleId,
                RoleName = User.RoleEntity.Name
            };
        }
    }
}
