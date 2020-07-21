using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Common;

namespace Services.Services
{
    public interface ISchoolStudentService
    {
        void InsertSchoolStudent(SchoolStudent model);
        void UpdateSchoolStudent(SchoolStudent model);

        void DeleteSchoolStudent(int id);

        object GetSchoolStudent(int id);

        object GetAllSchoolStudent(Pager page);
    }
}
