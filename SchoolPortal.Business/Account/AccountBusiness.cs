using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SchoolPortal.Business.Account.Model;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Domain.Entities;
using SchoolPortal.Shared.Common;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.Account
{
    public interface IAccountBusiness
    {
        public Task<BaseResponseModel<object>> Login(RequestLogin requestLogin);
        public Task<BaseResponseModel<object>> ManagerLogin(RequestManagerLogin requestManagerLogin);
    }
    public class AccountBusiness : IAccountBusiness
    {
        private readonly SchoolPortalDbContext _schoolDbContext;

        public AccountBusiness(SchoolPortalDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;

        }
        public async Task<BaseResponseModel<object>> ManagerLogin(RequestManagerLogin requestManagerLogin)
        {
            var account = _schoolDbContext.UserInfo.Where(x =>
                x.Username == requestManagerLogin.Username && x.Password == requestManagerLogin.Password &&
                x.Status == Enum.Status.Active && x.UserType == Enum.UserType.Manager).ToList();
            if (!account.Any() || account.Count() < 1)
            {
                return new BaseResponseModel<object>
                {
                    Data = null,
                    Message = "Kullanıcı adı veya şifre hatalı",
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false
                };
            }
            else
            {
                return new BaseResponseModel<object>
                {
                    Data = account.Select(x => new ResponseLogin { UserType = x.UserType, Username = x.Username, Id = x.Guid, Phone = x.Phone, SchoolId = x.FK_SchoolDetail }),
                    Message = "Başarılı",
                    StatusCode = HttpStatusCode.OK
                };
            }

        }
        public async Task<BaseResponseModel<object>> Login(RequestLogin requestLogin)
        {
            var account = _schoolDbContext.UserInfo.Where(x =>
                x.Phone == requestLogin.Phone && x.Password == requestLogin.Password &&
                x.Status == Enum.Status.Active && x.UserType == Enum.UserType.Student).ToList();
            if (!account.Any() || account.Count() < 1)
            {
                return new BaseResponseModel<object>
                {
                    Data = null,
                    Message = "Kullanıcı adı veya şifre hatalı",
                    StatusCode = HttpStatusCode.NotFound,
                    Success = false
                };
            }
            else
            {
                return new BaseResponseModel<object>
                {
                    Data = account.Select(x => new ResponseLogin { UserType = x.UserType, Username = x.Username, Id = x.Guid, Phone = x.Phone }),
                    Message = "Başarılı",
                    StatusCode = HttpStatusCode.OK
                };
            }

        }
    }
}
