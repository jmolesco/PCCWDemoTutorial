using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SchoolStudent : BaseEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual Students Student { get; set; }
    }
}
