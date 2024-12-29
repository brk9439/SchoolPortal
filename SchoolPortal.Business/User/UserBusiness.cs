using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolPortal.Business.Account.Model;
using SchoolPortal.Business.User.Model.Request;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Domain.Entities;
using SchoolPortal.Shared.Common;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.User
{
    public interface IUserBusiness
    {
        public Task<BaseResponseModel<object>> CreateUser(RequestCreateUser requestCreateUser);
        public Task<BaseResponseModel<object>> StudentRegister(RequestStudentRegister requestStudentRegister);
    }
    public class UserBusiness : IUserBusiness
    {
        private readonly SchoolPortalDbContext _schoolDbContext;

        public UserBusiness(SchoolPortalDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<BaseResponseModel<object>> CreateUser(RequestCreateUser requestCreateUser)
        {
            UserInfo userInfo = new UserInfo();

            userInfo.Guid = Guid.NewGuid();
            userInfo.UserType = Enum.UserType.Admin;
            userInfo.CreateDate = DateTime.UtcNow;
            userInfo.Status = Enum.Status.Active;
            userInfo.ExpireDate = DateTime.UtcNow.AddDays(25);
            userInfo.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            userInfo.Username = requestCreateUser.UserName;
            userInfo.Password = requestCreateUser.Password;
            userInfo.Phone = requestCreateUser.Phone;
            userInfo.Phone2 = requestCreateUser.Phone2;
            userInfo.FK_SchoolDetail = requestCreateUser.FK_SchoolDetail.Value;


            _schoolDbContext.UserInfo.Add(userInfo);
            _schoolDbContext.SaveChanges();


            return new BaseResponseModel<object>
            {
                Data = userInfo,
                Message = "Admin kayıt işlemi başarılı",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<BaseResponseModel<object>> StudentRegister(RequestStudentRegister requestStudentRegister)
        {
            UserInfo userInfo = new UserInfo();

            userInfo.Guid = Guid.NewGuid();
            userInfo.UserType = Enum.UserType.Student;
            userInfo.CreateDate = DateTime.UtcNow;
            userInfo.Status = Enum.Status.Active;
            userInfo.ExpireDate = DateTime.UtcNow.AddDays(25);
            userInfo.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            userInfo.Username = requestStudentRegister.Fullname;
            userInfo.Password = requestStudentRegister.Password;
            userInfo.Phone = requestStudentRegister.Phone;
            userInfo.Phone2 = null;
            userInfo.FK_SchoolDetail = requestStudentRegister.SchoolGuid;

            var user = _schoolDbContext.UserInfo.Where(x => x.Phone == requestStudentRegister.Phone && x.UserType == Enum.UserType.Student && x.Status == Enum.Status.Active).ToList();
            if (!user.Any() && user.Count()==0)
            {
                _schoolDbContext.UserInfo.Add(userInfo);
                _schoolDbContext.SaveChanges();
                return new BaseResponseModel<object>
                {
                  
                    Message = "Öğrenci kayıt işlemi başarılı",
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
            {
                return new BaseResponseModel<object>
                {
                    
                    Message = "Öğrenci kayıt işlemi başarısız",
                    StatusCode = HttpStatusCode.NoContent
                };

            }




        }
    }
}
