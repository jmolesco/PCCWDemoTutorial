using EducationSystem.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystem.Validator.Student
{
    public class InsertStudentValidator : AbstractValidator<StudentModel>
    {
        public InsertStudentValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(reg => reg.Name).NotEmpty().WithMessage("Input should not be empty").NotNull().WithMessage("Input should not be empty");
            RuleFor(reg => reg.Age).NotEmpty().WithMessage("Input should not be empty").NotNull().WithMessage("Input should not be empty");
        }
    }
}
