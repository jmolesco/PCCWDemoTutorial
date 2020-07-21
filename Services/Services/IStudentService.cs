using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Common;

namespace Services.Services
{
    public interface IStudentService
    {
        void InsertStudent(Students model);
        void UpdateStudent(Students model);

        void DeleteStudent(int id);

        Students GetStudent(int id);

        object GetAllStudent(Pager page);
    }
}
