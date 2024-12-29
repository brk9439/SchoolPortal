using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Business.School.Model.Request;
using SchoolPortal.Business.School.Model.Response;
using SchoolPortal.Infrastruct.Domain.Context;
using SchoolPortal.Infrastruct.Domain.Entities;
using SchoolPortal.Shared.Common;
using Enum = SchoolPortal.Infrastruct.Domain.Entities.Enum;

namespace SchoolPortal.Business.School
{
    public interface ISchoolBusiness
    {
        public Task<BaseResponseModel<object>> CreateSchool(RequestCreateSchool requestCreateSchool);
        public Task<BaseResponseModel<object>> GetSchoolList();
        public Task<BaseResponseModel<object>> SchoolInfo(Guid id);
        public Task<BaseResponseModel<object>> GetStudentList(Guid schoolId);
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


            var response = new BaseResponseModel<object>()
            {
                Data = school,
                Message = "Okul Kayıt işlemi başarılı",
                StatusCode = HttpStatusCode.OK
            };
            return response;

        }

        public async Task<BaseResponseModel<object>> GetSchoolList()
        {
            var response = new BaseResponseModel<object>
            {
                Data = await _schoolPortalDbContext.SchoolDetail.Where(x => x.Status == Enum.Status.Active).ToListAsync(),
                Message = "Tüm okullar listelendi",
                StatusCode = HttpStatusCode.OK
            };
            return response;
        }
        public async Task<BaseResponseModel<object>> SchoolInfo(Guid id)
        {
            var response = new BaseResponseModel<object>
            {
                Data = await _schoolPortalDbContext.SchoolDetail.Where(x => x.Guid == id).Select(x => new ResponseSchoolInfo { Guid = x.Guid, Name = x.SchoolName }).ToListAsync(),
                Message = "İlgili okul listelendi",
                StatusCode = HttpStatusCode.OK
            };
            return response;
        }

        public async Task<BaseResponseModel<object>> GetStudentList(Guid schoolId)
        {
            var response = new BaseResponseModel<object>
            {
                Data = await _schoolPortalDbContext.UserInfo.Where(x => x.FK_SchoolDetail == schoolId && x.UserType == Enum.UserType.Student && x.Status == Enum.Status.Active).Select(x => new ResponseStudentList { Id = x.Guid, Phone = x.Phone, Fullname = x.Username, Mail = "", Phone2 = x.Phone2, CreateDate = x.CreateDate }).ToListAsync(),
                Message = "Tüm öğrenciler listelendi",
                StatusCode = HttpStatusCode.OK,

            };
            return response;
        }
    }
}
