using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Domain.Entities;
using SchoolPortal.Shared.Common;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.Account
{
	public interface IAccountBusiness
    {
        public  Task<BaseResponseModel<object>> Login(string username, string password);

    }
	public class AccountBusiness : IAccountBusiness
	{
		private readonly SchoolPortalDbContext _schoolDbContext;

		public AccountBusiness(SchoolPortalDbContext schoolDbContext)
		{
			_schoolDbContext = schoolDbContext;

		}

		public async Task<BaseResponseModel<object>> Login(string username, string password)
		{
			var userInfo = new UserInfo
			{
				CreateDate = DateTime.Now,
				ExpireDate = DateTime.Now.AddDays(45),
				FK_SchoolDetail = new Guid(),
				UpdateTime = DateTime.Now,
				Guid = new Guid(),
				Password = password,
				Username = username,
				Phone = "",
				Phone2 = "",
				Photo = "",
				RefreshToken = "",
				Status = Enum.Status.Active,
				UserType = Enum.UserType.Admin

			};
			_schoolDbContext.UserInfo.AddAsync(userInfo);
			_schoolDbContext.SaveChangesAsync();

			return new BaseResponseModel<object>
			{
				Message = "Message",
				StatusCode = HttpStatusCode.OK
			};
		}
	}
}
