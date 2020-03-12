using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BL.Commons;
using BL.Helpers;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BL.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserHelper _userHelper;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;


        public UserLogic(IOptions<AppSettings> appSettings, UserHelper userHelper, IUnitOfWork uow, IMapper mapper)
        {

            _userHelper = userHelper;
            _mapper = mapper;
            _uow = uow;
            _appSettings = appSettings.Value;
        }

        public List<UserDetailDto> GetListUser()
        {
            List<UserDetailDto> rs = new List<UserDetailDto>();
            var l = _uow.GetRepository<UserEntity>().GetAll().ToList();
            foreach (UserEntity user in l)
            {
                rs.Add(new UserDetailDto
                {
                    Id = user.Id,
                    UserName =  user.UserName
                });
            }

            return rs;
        }


        //business logic Login
        public UserDetailDto Login(string userid, string password)
        {


            var User = _uow.GetRepository<UserEntity>().GetAll()
                .FirstOrDefault(user => user.Id == userid && user.Password == password);

            if (User == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserDetailDto
            {
                UserName = User.UserName,
                Token = tokenString,
                Id = User.Id,
                RoleId = User.RoleId
            };
        }

        public UserDetailDto GetUserDetailById(string id)
        {
            var entity = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.Id == id);
            var result = _mapper.Map<UserDetailDto>(entity);
            return result ;
        }
        public List<UserDetailDto> GetListUserDetail()
        {
            var entity = _uow.GetRepository<UserEntity>().GetAll().Include(c => c.RoleEntity).ToList();
            var result = _mapper.Map<List<UserDetailDto>>(entity);
            return result ;
        }

        public bool DeleteUserById(string id)
        {
            var entity = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.Id == id);
            if(entity != null) { 
            _uow.GetRepository<UserEntity>().Delete(entity);
            _uow.SaveChange();
            return true;
            }

            return false;
        }

        public bool CreateUser(CreateNewUserRequest request)
        {
            try
            {
                
                _uow.GetRepository<UserEntity>().Insert(new UserEntity
                {
                    Id = request.UserId,
                    Password = request.Password,
                    RoleId = request.RoleId,
                    UserName = request.Name,
                    UpdateTime = DateTime.Now,
                    UpdatedBy = _userHelper.GetUserId()
                });
                
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }

        public bool UpdateUser(CreateNewUserRequest request)
        {
            try
            {
                var entity = _mapper.Map<UserEntity>(request);
                var t = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.Id == request.UserId);
                if (t != null)
                {
                    t.UpdateTime = DateTime.Now;
                    t.UpdatedBy = _userHelper.GetUserId();
                    t.RoleId = request.RoleId;
                    t.UserName = request.Name;
                    t.Password = request.Password;
                    _uow.GetRepository<UserEntity>().Update(t);
                }
                else
                {
                    return false;
                }
                
                
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }
    }
}
