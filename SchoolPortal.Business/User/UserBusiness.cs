using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            UserInfo userInfo = new UserInfo
            {
                Guid = Guid.NewGuid(),
                UserType = Enum.UserType.Admin,
                CreateDate = DateTime.UtcNow,
                Status = Enum.Status.Active,
                ExpireDate = DateTime.UtcNow.AddDays(25),
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)),
                Username = requestCreateUser.UserName,
                Password = requestCreateUser.Password,
                Phone = requestCreateUser.Phone,
                Phone2 = requestCreateUser.Phone2,
                FK_SchoolDetail = requestCreateUser.FK_SchoolDetail.Value

            };
            await _schoolDbContext.UserInfo.AddAsync(userInfo);
            await _schoolDbContext.SaveChangesAsync();


            return new BaseResponseModel<object>
            {
                Data = userInfo,
                Message = "Admin kayıt işlemi başarılı",
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
