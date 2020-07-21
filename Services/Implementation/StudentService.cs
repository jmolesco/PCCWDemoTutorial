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
    public class StudentService : IStudentService
    {
        private readonly IBaseRepository<Students> _studentRepository; 
        public StudentService(IBaseRepository<Students> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void InsertStudent(Students model)
        {
            _studentRepository.Insert(model);
            _studentRepository.SaveChanges();
        }

        public void UpdateStudent(Students model)
        {
            var result = _studentRepository.Get(obj => obj.StudentId == model.StudentId);
            if (result !=null)
            {
                result.Name = model.Name;
                result.Age = model.Age;
                _studentRepository.Update(model);
                _studentRepository.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var result = _studentRepository.Get(obj => obj.StudentId == id);
            _studentRepository.Remove(result);
            _studentRepository.SaveChanges();
        }

        public Students GetStudent(int id)
        {
            var result = _studentRepository.Get(obj => obj.StudentId == id);
            return result;
        }

        public object GetAllStudent(Pager page)
        {
            var records = _studentRepository.Queryable().AsNoTracking().
                Select(p=> new {
                    p.StudentId,
                    p.Name,
                    p.Age,
                    DateCreated = p.dateCreated,
                    DateModified = p.dateModified
                });

            if (page.Keyword.HasValue())
            {
                records = records.Where(p => p.Name.Contains(page.Keyword));
            }

            GetAllResponse response = null;
            int maxRecord = 10;
            if(page.ShowAll == false)
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
