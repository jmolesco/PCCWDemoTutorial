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
    public class SchoolService : ISchoolService
    {
        private readonly IBaseRepository<School> _schoolRepository;
        public SchoolService(IBaseRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void InsertSchool(School model)
        {
            _schoolRepository.Insert(model);
            _schoolRepository.SaveChanges();
        }

        public void UpdateSchool(School model)
        {
            var result = _schoolRepository.Get(obj => obj.SchoolId == model.SchoolId);
            if (result != null)
            {
                result.SchoolName = model.SchoolName;
                result.Address = model.Address;
                _schoolRepository.Update(model);
                _schoolRepository.SaveChanges();
            }
        }

        public void DeleteSchool(int id)
        {
            var result = _schoolRepository.Get(obj => obj.SchoolId == id);
            _schoolRepository.Remove(result);
            _schoolRepository.SaveChanges();
        }

        public School GetSchool(int id)
        {
            var result = _schoolRepository.Get(obj => obj.SchoolId == id);
            return result;
        }

        public object GetAllSchool(Pager page)
        {
            var records = _schoolRepository.Queryable().AsNoTracking().
                Select(p => new {
                    p.SchoolId,
                    p.SchoolName,
                    p.Address,
                    DateCreated = p.dateCreated,
                    DateModified = p.dateModified
                });

            if (page.Keyword.HasValue())
            {
                records = records.Where(p => p.SchoolName.Contains(page.Keyword));
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
