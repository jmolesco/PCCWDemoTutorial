using Domain;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Common;
using Utility.Extension;
using Utility.Response;

namespace Services.Implementation
{
    public class SchoolStudentService : ISchoolStudentService
    {
        private readonly IBaseRepository<SchoolStudent> _schoolStudentRepository;
        public SchoolStudentService(IBaseRepository<SchoolStudent> schoolStudentRepository)
        {
            _schoolStudentRepository = schoolStudentRepository;
        }

        public void InsertSchoolStudent(SchoolStudent model)
        {
            _schoolStudentRepository.Insert(model);
            _schoolStudentRepository.SaveChanges();
        }

        public void UpdateSchoolStudent(SchoolStudent model)
        {
            var result = _schoolStudentRepository.Get(obj => obj.SchoolId == model.SchoolId);
            if (result != null)
            {
                result.SchoolId = model.SchoolId;
                result.StudentId = model.StudentId;
                _schoolStudentRepository.Update(model);
                _schoolStudentRepository.SaveChanges();
            }
        }

        public void DeleteSchoolStudent(int id)
        {
            var result = _schoolStudentRepository.Get(obj => obj.SchoolId == id);
            _schoolStudentRepository.Remove(result);
            _schoolStudentRepository.SaveChanges();
        }

        public object GetSchoolStudent(int id)
        {
            var result = _schoolStudentRepository.Get(obj => obj.SchoolId == id);
            return result;
        }

        public object GetAllSchoolStudent(Pager page)
        {
            var records = _schoolStudentRepository.Queryable().AsNoTracking().
                Include(p=> p.Student).
                Include(p=> p.School).                
                Select(p => new {
                    p.SchoolId,
                    p.School.SchoolName,
                    p.School.Address,
                    p.Student.Name,
                    p.Student.Age,
                    DateCreated = p.dateCreated,
                    DateModified = p.dateModified
                });

            if (page.Keyword.HasValue())
            {
                records = records.Where(p => p.SchoolName.Contains(page.Keyword) || p.Name.Contains(page.Keyword));
            }

            GetAllResponse response = null;
            int maxRecord = 10;
            if (page.ShowAll == false)
            {
                response = new GetAllResponse(records.Count(), page.CurrentPage, maxRecord);
                records = records.Skip((page.CurrentPage - 1) * maxRecord);
            }
            else
            {
                response = new GetAllResponse(records.Count());
            }

            response.List.AddRange(records);


            return response;
        }
    }
}
