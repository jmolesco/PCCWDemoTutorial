using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Common;

namespace Services.Services
{
    public interface ISchoolService
    {
        void InsertSchool(School model);
        void UpdateSchool(School model);

        void DeleteSchool(int id);

        School GetSchool(int id);

        object GetAllSchool(Pager page);
    }
}
