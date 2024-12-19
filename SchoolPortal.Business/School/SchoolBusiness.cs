using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SchoolPortal.Business.School.Model.Request;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Domain.Entities;
using SchoolPortal.Shared.Common;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.School
{
    public interface ISchoolBusiness
    {
        public Task<BaseResponseModel<object>> CreateSchool(RequestCreateSchool requestCreateSchool);
    }
    public class SchoolBusiness : ISchoolBusiness
    {
        private readonly SchoolPortalDbContext _schoolPortalDbContext;
        public SchoolBusiness(SchoolPortalDbContext schoolPortalDbContext)
        {
            _schoolPortalDbContext = schoolPortalDbContext;
        }

        public async Task<BaseResponseModel<object>> CreateSchool(RequestCreateSchool requestCreateSchool)
        {
            var school = new SchoolDetail
            {
                Guid = Guid.NewGuid(),
                SchoolName = requestCreateSchool.Name,
                Address = requestCreateSchool.Address,
                City = requestCreateSchool.City,
                Status = Enum.Status.Active,
                CreateDate = DateTime.UtcNow,

            };
            await _schoolPortalDbContext.SchoolDetail.AddAsync(school);
            _schoolPortalDbContext.SaveChanges();


            return new BaseResponseModel<object> { Data = school, Message = "Okul kayıt işlemi başarılı", StatusCode = HttpStatusCode.OK };
        }
    }
}
